using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 5.0f;

    private float movementX;
    private float movementY;

    private Rigidbody2D rb;
    private Animator animator;

    private Vector3 initialScale;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        initialScale = transform.localScale;
    }

    void OnMove(InputValue inputValue)
    {
        Vector2 movementVector = inputValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void FixedUpdate()
    {
        Vector2 moveInput = new Vector2(movementX, movementY);

        Vector2 moveVelocity = moveInput.normalized * movementSpeed;
        rb.velocity = moveVelocity;

        bool isRunning = moveInput.magnitude > 0;

        animator.SetBool("IsRunning", isRunning);

        if (isRunning)
        {
            if (movementX > 0)
            {
                transform.localScale = new Vector3(initialScale.x, initialScale.y, initialScale.z);
            }
            else if (movementX < 0)
            {
                transform.localScale = new Vector3(-initialScale.x, initialScale.y, initialScale.z);
            }
        }
    }
}
