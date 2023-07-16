using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace S
{
    public class PlayerMovement : MonoBehaviour
    {
        private Rigidbody2D rb;
        private BoxCollider2D coll;
        private SpriteRenderer sprite;
        private Animator anim;
        //direction ve movespeed vs giriyorum aşağıya
        [SerializeField] private LayerMask jumpableGround;
        private float dirX = 0f;

        [SerializeField] private float moveSpeed = 7f;
        [SerializeField] private float jumpForce = 14f;

        private enum MovementState { idle, running, jumping, falling, comelme }
        [SerializeField] private AudioSource jumpsoundSoundEffect;

        void Start()
        {
            rb = GetComponent<Rigidbody2D>();

            coll = GetComponent<BoxCollider2D>();

            sprite = GetComponent<SpriteRenderer>();
            anim = GetComponent<Animator>();
        }
        void Update()
        {
            dirX = Input.GetAxisRaw("Horizontal");
            if (rb.bodyType != RigidbodyType2D.Static)
            {
                rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
            }
            if (Input.GetButtonDown("Jump") && IsGrounded())
            {
                jumpsoundSoundEffect.Play();
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
            UpdateAnimationState();
        }

        private void UpdateAnimationState()
        {
            MovementState state;
            if (dirX > 0f)
            {
                state = MovementState.running;
                sprite.flipX = false;
            }
            else if (dirX < 0f)
            {
                state = MovementState.running;
                sprite.flipX = true;
            }
            else
            {
                state = MovementState.idle;
            }

            if (rb.velocity.y > .1f)
            {
                state = MovementState.jumping;
            }
            else if (rb.velocity.y < -.1f)
            {
                state = MovementState.falling;
            }
            anim.SetInteger("state", (int)state);
        }
        private bool IsGrounded()
        {
            return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
        }
    }
}