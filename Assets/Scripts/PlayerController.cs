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
    private Vector2 mousePosition;
    private Animator animator;
    public GameObject bullet;
    private Vector3 bulletDirection;
    public Transform shootFrom;
    public Quaternion playerRotation;

    public void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        SetStartPos();
        
    }
    private void Start()
    {
        playerRotation = gameObject.transform.rotation;
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

    public void OnFire(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Fire();
        }
    }


    

    public void Fire()
    {
        Quaternion bulletRotation = playerRotation;
        
        GameObject firedBullet = Instantiate(bullet, shootFrom.transform.position, bulletRotation, null);
        firedBullet.GetComponent<Bullet>().bulletDirection = bulletDirection;
        firedBullet.GetComponent<Bullet>().bulletRotation = bulletRotation;
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

    public void Update()
    {
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector2 direction = (mouseWorldPosition - transform.position);
        bulletDirection = direction.normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Rotate the player on Z-axis to face the mouse
        playerRotation = Quaternion.Euler(0f, 0f, angle);
        transform.rotation = playerRotation;
       
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        mousePosition = context.ReadValue<Vector2>();
        
       
    }


}
