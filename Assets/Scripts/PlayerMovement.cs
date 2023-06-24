using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    private Animator _animator;
    public float runSpeed = 40f;
    private bool jump = false;
    private float horizontalMove = 0f;
    
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        _animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump = true;
         _animator.SetBool("jump",true);
        }
        
    }
    public void OnLanding ()
    {
        _animator.SetBool("IsJumping", false);
    }
    void FixedUpdate ()
    {
        // Move our character
        controller.Move(horizontalMove * Time.fixedDeltaTime, jump);
        jump = false;
    }
}
