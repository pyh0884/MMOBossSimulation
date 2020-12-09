using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Slider healthBar;
    public float maxHealth = 100.0f;
    public float currentHealth = 100.0f;
    private bool isDead;
    public void TakeDamege(float damage)
    {
        if (isDead) return;
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Dead();
        }
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
    }

    public void Dead() 
    {
        isDead = true;
        Destroy(gameObject);
        //TODO: Add death animation/EFX
    }

    void Update()
    {
        healthBar.value = currentHealth / maxHealth;
    }
}
