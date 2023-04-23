using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float collisionOffset = 0.05f;
    public ContactFilter2D movementFilter;

    private Vector2 moveInput;
    private List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();
    private Rigidbody2D rb;
    
    private Animator animator;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>(); // Get player animator
    }

    public void FixedUpdate()
    {

        // rb.MovePosition(rb.position + (moveInput * moveSpeed * Time.fixedDeltaTime));

        if (moveInput != Vector2.zero)
        {
            // Try to move player in input direction, followed by left right and up down input if failed
            bool success = MovePlayer(moveInput);

            if (!success)
            {
                // Try Left / Right
                success = MovePlayer(new Vector2(moveInput.x, 0));

                if (!success)
                {
                    success = MovePlayer(new Vector2(0, moveInput.y));
                }
            }

            animator.SetBool("isMoving", success);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }


    }

    public bool MovePlayer(Vector2 direction)
    {
        // Check for potential collisions
        int count = rb.Cast(
            direction, // X and Y values between -1 and 1 that represent the direction from the body to look for collisions
            movementFilter, // The settings that determine where a collision can occur on such as layers to collide with
            castCollisions, // List of collisions to store the found collisions into after the Cast is finished
            moveSpeed * Time.fixedDeltaTime + collisionOffset); // The amount to cast equal to the movement plus an offset

        if (count == 0)
        {
            Vector2 moveVector = direction * moveSpeed * Time.fixedDeltaTime;

            // No collisions
            rb.MovePosition(rb.position + moveVector);
            return true;
        }
        else
        {
            // Print collisions
            foreach (RaycastHit2D hit in castCollisions)
            {
                print(hit.ToString());
            }

            return false;
        }
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
        if (moveInput != Vector2.zero)
        {
            animator.SetFloat("XInput", moveInput.x);
            animator.SetFloat("YInput", moveInput.y);
        }
    }

    void OnFire()
    {
        print("Meow");
    }
}