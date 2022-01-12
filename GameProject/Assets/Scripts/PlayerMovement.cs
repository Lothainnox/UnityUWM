using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    
    bool jump = false;

   
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
    }

    void FixedUpdate()
    {
        controller.Move(LevelManager.runSpeed * Time.fixedDeltaTime, jump);
        jump = false;
    }
}
