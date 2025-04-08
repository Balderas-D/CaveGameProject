using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Animator animator;

    public void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        SetStartPos(); 
    }

    private void SetStartPos()
    {
        string start = PlayerPrefs.GetString("Start", "Center");
        float Y = PlayerPrefs.GetFloat("Y", 0);
        if (start == "Center")
        {
            gameObject.transform.position = Vector3.zero;
        }
        else if (start == "Left")
        {
           gameObject.transform.position = new Vector3(-9,Y,0);
        }
        else if(start == "Right")
        {
            gameObject.transform.position = new Vector3(9, Y, 0);
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            moveInput = context.ReadValue<Vector2>();
            animator.SetFloat("MoveX", moveInput.x);
            animator.SetFloat("MoveY", moveInput.y);
        }

        if (context.canceled) 
        {
            moveInput = Vector2.zero;
        }
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Attack();
        }
    }

    public void Attack()
    {
        Debug.Log("Attack");
    }

    private void FixedUpdate()
    {
        if (moveInput != Vector2.zero)
        {
            animator.SetBool("Walking", true);
        }
        else
        {
            animator.SetBool("Walking", false);
        }
        rb.velocity = moveInput * moveSpeed;
    }


}
