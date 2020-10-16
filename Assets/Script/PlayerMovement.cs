using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;
    public float runSpeed = 40f;
    float horizontalMove = 0f;
    bool jump = false;
    public Animator animator;


    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        if (Input.GetButtonDown("Jump")) {
            jump = true;
            animator.SetBool("Jumping", true);
            if (Input.GetKeyDown(KeyCode.Z))          
            {
                JumpAttack();
            }
        }
    }

    private void JumpAttack()
    {
        animator.SetTrigger("jumpAttack");
    }

    public void OnLanding() {
        animator.SetBool("Jumping", false);
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove*Time.fixedDeltaTime, false, jump);
        jump = false;
    }
}
