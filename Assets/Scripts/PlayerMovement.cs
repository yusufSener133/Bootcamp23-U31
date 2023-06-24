using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
   
    public float runSpeed = 40f;
    private bool jump = false;
    private float horizontalMove = 0f;
    
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
         
        }
    }
    public void OnLanding ()
    {
      
    }
    void FixedUpdate ()
    {
        // Move our character
        controller.Move(horizontalMove * Time.fixedDeltaTime, jump);
        jump = false;
    }
}
