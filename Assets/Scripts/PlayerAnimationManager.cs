using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationManager : MonoBehaviour
{
    private Animator animator;
    private CharacterMovement movement;

    //added this due to bug I was encountering where the falling animation would randomly play
    private float groundCheckTimer = 0f;  
    public float groundCheckDelay = 0.1f; 

    public void Start()
    {
        animator = GetComponent<Animator>();
        movement = GetComponent<CharacterMovement>();
    }

    public void Update()
    {
        animator.SetFloat("CharacterSpeed", movement.GetMoveSpeed());

        if (!movement.isGrounded)
        {
            groundCheckTimer += Time.deltaTime;

            if (groundCheckTimer >= groundCheckDelay)
            {
                animator.SetBool("IsFalling", true);
            }
        }
        else
        {
            groundCheckTimer = 0f;
            animator.SetBool("IsFalling", false);
        }
        if (Input.GetButtonUp("Fire1"))
        {
            animator.SetTrigger("doRoll");
        }
    }
}


