using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    private int currentHealth = 0;
    private int MaxHealth = 200;

    public HealthBar healthbar;
    public GameObject gunDrop;
    public GameObject ammoDrop;

    void Start()
    {
        currentHealth = MaxHealth;
        healthbar.SetMaxHealth(MaxHealth);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Bullet bulletH = collision.gameObject.GetComponent<Bullet>();

        if (bulletH != null)
        {
            currentHealth -= 20;
            healthbar.SetHealth(currentHealth);
            Death();
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "SpecialBullet")
        {
            currentHealth -= 50;
            healthbar.SetHealth(currentHealth);
            Death();
        }
    }

    private void Death()
    {
        if (currentHealth <= 0)
        {
            BossDrops();
            Destroy(gameObject);
        }
    }

    private void BossDrops()
    {
        Instantiate(ammoDrop, this.transform.position, Quaternion.identity);
        Instantiate(gunDrop, this.transform.position, Quaternion.identity);
    }
}
