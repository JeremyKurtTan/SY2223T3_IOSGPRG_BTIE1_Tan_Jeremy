using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private int currentHealth = 0;
    private int MaxHealth = 100;

    public HealthBar healthbar;

    void Start()
    {
        currentHealth = MaxHealth;
        healthbar.SetMaxHealth(MaxHealth);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Hit");
        Bullet bulletH = collision.gameObject.GetComponent<Bullet>();
        if (bulletH != null)
        {
            currentHealth -= 20;
            healthbar.SetHealth(currentHealth);
            Death();        
        }
    }

    void Death()
    {
        if(currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
