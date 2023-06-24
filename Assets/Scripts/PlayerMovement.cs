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
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump = true;
         Debug.Log("jumping triggerd");
        }
        // Move our character
        controller.Move(horizontalMove * Time.fixedDeltaTime, jump);
        jump = false;
    }
    public void OnLanding ()
    {
      
    }
    void FixedUpdate ()
    {
        
    }
}
