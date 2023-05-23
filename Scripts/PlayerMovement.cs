using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{ 
    public CharacterController2D Controller;

    public float runSpeed = 40f;

    private float horizontalMoves = 0f;
    private bool jump = false;

    // Update is called once per frame
    void Update()
    {
        horizontalMoves = Input.GetAxisRaw("Horizontal") * runSpeed;
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
    }

    private void FixedUpdate()
    {
        // karakter hareketi
        Controller.Move(horizontalMoves * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
}