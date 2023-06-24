using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private float m_JumpForce = 400f;
    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f; // How much to smooth out the movement

    [SerializeField] private bool m_AirControl = false; // Whether or not a player can steer while jumping;
    [SerializeField] private LayerMask m_WhatIsGround; // A mask determining what is ground to the character
    [SerializeField] private Transform m_GroundCheck; // A position marking where to check if the player is grounded.

    private Rigidbody player_Rb;
    private bool m_FacingRight = true; // For determining which way the player is currently facing.
    private Vector3 m_Velocity = Vector3.zero;
    const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
    private bool m_Grounded; // Whether or not the player is grounded.

    [Header("Events")] [Space] public UnityEvent OnLandEvent;

    void Awake()
    {
        player_Rb = GetComponent<Rigidbody>();
        if (OnLandEvent == null)
            OnLandEvent = new UnityEvent();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        bool wasGrounded = m_Grounded;
        m_Grounded = false;

        // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
        // This can be done using layers instead but Sample Assets will not overwrite your project settings.
        Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                m_Grounded = true;
                if (!wasGrounded)
                    OnLandEvent.Invoke();
            }
        }
    }

    public void Move(float move, bool jump)
    {
        if (m_Grounded||m_AirControl)
        {
            // Move the character by finding the target velocity
            Vector3 targetVelocity = new Vector2(move * 10f, player_Rb.velocity.y);
            // And then smoothing it out and applying it to the character
            player_Rb.velocity =
                Vector3.SmoothDamp(player_Rb.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);

            // If the input is moving the player right and the player is facing left...
            if (move > 0 && !m_FacingRight)
            {
                // ... flip the player.
                Flip();
            }
            // Otherwise if the input is moving the player left and the player is facing right...
            else if (move < 0 && m_FacingRight)
            {
                // ... flip the player.
                Flip();
            }
        }

        // If the player should jump...
        if (m_Grounded && jump)
        {
            // Add a vertical force to the player.
            m_Grounded = false;
            player_Rb.AddForce(new Vector2(0f, m_JumpForce));
        }
    }
    
    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;
        transform.localScale = flipped;

        transform.Rotate(0f, 180f, 0f);
    }
}

