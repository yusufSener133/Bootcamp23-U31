using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovementece : MonoBehaviour
{
    [SerializeField] float speed;

    float hor;

    Vector2 movement;

    Rigidbody2D PlayerRB;
    Animator playerAnim;
    SpriteRenderer playerSR;

    public void Start()
    {
        PlayerRB = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
        playerSR = GetComponent<SpriteRenderer>();
    }

    public void FixedUpdate()
    {
        //transform.Translate(Vector2.right * speed * Time.deltaTime);
        //ManuelMovement();

        //inputVector.x = Input.GetAxisRaw("Horizontal");
        //inputVector.y = Input.GetAxisRaw("Vertical");

        //transform.Translate(inputVector.normalized * speed);
        //transform.Translate(newInputVector * speed);

        if (Mathf.Abs(movement.x) > 0f)
        {
            movement.y = 0;
        }

        PlayerRB.velocity = movement * speed;

    }

    public void Update()
    {

        SetDirection();
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            movement.x = Input.GetAxis("Horizontal");
            movement.y = Input.GetAxis("Vertical");
            playerAnim.SetBool("isWalk", true);


        }
        else
        {
            playerAnim.SetBool("isWalk", false);
        }
    }

    /*void ManuelMovement()
    {
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                transform.Translate(Vector2.one.normalized * speed);
            }
            else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                transform.Translate(new Vector2(1, -1).normalized * speed);
            }
            else
            {
                transform.Translate(Vector2.right * speed);
            }
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                transform.Translate(new Vector2(-1, 1).normalized * speed);
            }
            else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                transform.Translate(Vector2.one.normalized * -speed);
            }
            else
            {
                transform.Translate(Vector2.left * speed);
            }
        }
        else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector2.up * speed);
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector2.down * speed);
        }
    }*/

    /*void SetAnim()
    {
        if (PlayerRB.velocity != Vector2.zero)
        {
            playerAnim.SetBool("isWalk", true);
        }
        else
        {
            playerAnim.SetBool("isWalk", false);
        }
    
    }*/

    void SetDirection()
    {
        if (movement.x < 0f)
        {
            playerSR.flipX = true;
        }
        else
        {
            playerSR.flipX = false;
        }
    }
    public void OnMovement(InputValue value)
    {
        movement = value.Get<Vector2>();


    }
}
