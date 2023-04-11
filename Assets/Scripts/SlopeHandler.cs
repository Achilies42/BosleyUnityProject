using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlopeHandler : MonoBehaviour
{
    public float slopeAngle = 30f; // The angle of the slope in degrees
    public Vector2 slopeDirection = Vector2.right; // The direction of the slope

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player")) // Assuming the player has a "Player" tag
        {
            // Check if the collision contact point is on the slope
            ContactPoint2D contact = collision.GetContact(0);
            Vector2 normal = contact.normal;
            float angle = Vector2.Angle(normal, slopeDirection);
            if (angle <= slopeAngle)
            {
                // Calculate the desired upward movement direction
                Vector2 slopeNormal = new Vector2(normal.y, -normal.x).normalized;
                Vector2 moveDirection = Vector2.Lerp(Vector2.up, slopeNormal, angle / slopeAngle);

                // Apply the desired movement to the player
                Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();
                rb.velocity = new Vector2(rb.velocity.x, 0f);
                rb.AddForce(moveDirection * collision.relativeVelocity.magnitude, ForceMode2D.Impulse);
            }
        }
    }
}
