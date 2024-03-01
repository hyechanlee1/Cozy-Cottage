using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    Animator animator;
    [SerializeField] float movementSpeed = 5f;
    [SerializeField] float sprintMultiplier = 2f;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput).normalized;
        float currentSpeed = Input.GetButton("Sprint") ? movementSpeed * sprintMultiplier : movementSpeed;

        // Determine if the character is moving and set the animator speed parameter
        if (movementDirection != Vector3.zero)
        {
            animator.SetFloat("speed", 1);
            
            // Rotate character to face movement direction
            Quaternion targetRotation = Quaternion.LookRotation(movementDirection);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * 10f);
        }
        else
        {
            animator.SetFloat("speed", 0);
        }

        // Apply movement
        rb.velocity = new Vector3(movementDirection.x * currentSpeed, rb.velocity.y, movementDirection.z * currentSpeed);
    }
}
