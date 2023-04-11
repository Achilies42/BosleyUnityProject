using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidTile : MonoBehaviour
{
    public int damageAmount = 10; // Amount of damage to apply to the player
    public string playerTag = "Player"; // Tag used to identify the player
    // Optional: Add visual effects or other properties as needed

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the collision is with the player
        if (collision.gameObject.CompareTag(playerTag))
        {
            // Get the PlayerHealth script attached to the player
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();

            // Apply damage to the player
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageAmount);
            }
        }
    }
}