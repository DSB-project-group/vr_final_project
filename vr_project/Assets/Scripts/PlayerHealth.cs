using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float currentHealth;
    public float maxHealth = 100;
    public float damageAmount = 5; // Adjust this value based on your game's balance

    public Slider HealthBar;

    public bool isDead = false;

    private void Start()
    {
        HealthBar.minValue = 0;
        HealthBar.maxValue = maxHealth;
        currentHealth = maxHealth;
    }

    private void Update()
    {
        HealthBar.value = currentHealth;
        UpdateHealthBar();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("hitbox")) // Assuming your monster's hand has a tag named "MonsterHand"
        {
            TakeDamage(damageAmount);
        }
    }

    void TakeDamage(float damage)
    {
        if (!isDead)
        {
            currentHealth -= damage;
        }
        // Update health bar or perform actions based on the player's health
        

        if (currentHealth <= 0)
        {
            // Player dies or any other necessary actions
            isDead = true;
        }
    }

    void UpdateHealthBar()
    {
        HealthBar.value = currentHealth; // Update UI health bar value
    }

}
