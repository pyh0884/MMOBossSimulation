using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Slider healthBar;
    public float maxHealth = 100.0f;
    public float currentHealth = 100.0f;
    public void TakeDamege(float damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
    }
    void Update()
    {
        healthBar.value = currentHealth / maxHealth;
    }
}
