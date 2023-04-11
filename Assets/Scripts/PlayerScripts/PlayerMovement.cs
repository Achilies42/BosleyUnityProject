using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public float slopeCheckDistance = 0.5f;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private bool isGrounded;
    private bool isOnSlope;
    private float slopeAngle;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Move left or right
        float moveDirection = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);

        // Check for grounded
        isGrounded = Physics2D.OverlapCircle(transform.position, 0.2f, groundLayer);

        // Check for slope
        isOnSlope = false;
        slopeAngle = 0f;

        if (isGrounded)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, slopeCheckDistance, groundLayer);
            if (hit.collider != null)
            {
                isOnSlope = true;
                slopeAngle = Vector2.Angle(hit.normal, Vector2.up);
            }
        }

        // Jump
        if (Input.GetKeyDown(KeyCode.Space) && (isGrounded || isOnSlope))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
}

