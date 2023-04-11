using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public TMP_Text healthText;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthText();
    }

    void UpdateHealthText()
    {
        healthText.SetText("Health:  " + currentHealth.ToString());
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        UpdateHealthText();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Perform death logic, e.g. play death animation, game over, etc.
        Debug.Log("AVOM has died");
    }

    public void Heal(int healAmount)
    {
        currentHealth += healAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthText();
    }
}