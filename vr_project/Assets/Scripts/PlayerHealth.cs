using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
        isDead = false;
    }

    private void Update()
    {
        HealthBar.value = currentHealth;
        UpdateHealthBar();

        if (currentHealth <= 0 && !isDead)
        {
            // Call the function to reset the scene when health reaches zero
            ResetScene();
            isDead = true; // Prevents multiple resets if the health stays at zero
        }
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
 
    }

    void UpdateHealthBar()
    {
        HealthBar.value = currentHealth; // Update UI health bar value
    }

    void ResetScene()
    {
        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
