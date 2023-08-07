using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public bool isPlayerDead = false;
    public HealthBar healthbar;
    public bool canHeal = true;
    public HealingTime healingBar;
    public TMP_Text healnumberText;

    [SerializeField] private int currentHealth = 0;
    [SerializeField] private int MaxHealth = 100;
    [SerializeField] private float healDuration = 0f;
    [SerializeField] private int stimpackHealAmount = 30;
    [SerializeField] private MenuStuff menustuff;
    [SerializeField] private Inventory playerInventory;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private PlayerShoot playerShoot;

    private void Update()
    {
        HealText();
        healnumberText.text = healDuration.ToString();
        if (playerShoot.isShooting)
        {
            StopCoroutine("Healing");
            playerController.moveSpeed = 10f;
        }
    }

    void Start()
    {
        currentHealth = MaxHealth;
        healthbar.SetMaxHealth(MaxHealth);
        menustuff = this.GetComponent<MenuStuff>();
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
        if(currentHealth <= 0)
        {
            isPlayerDead = true;
            Destroy(gameObject);
            menustuff.Restart();
        }
    }

    public void UseHeal()
    {
        if (playerInventory.Inventory_StimpackAmount <= 0)
            return;

        if(canHeal)
        {
            healDuration = 3;
            healnumberText.text = healDuration.ToString();
            StartCoroutine("Healing");
            healingBar.IncrementBar(healDuration);
        }
    }

    public IEnumerator Healing()
    {
        playerController.moveSpeed = 5f;
        yield return new WaitForSeconds(healDuration);
        playerController.moveSpeed = 10f;

        playerInventory.Inventory_StimpackAmount -= 1;
        currentHealth += stimpackHealAmount;

        healthbar.SetHealth(currentHealth);
        healingBar.ResetBar();
        healingBar.targetProgress = 0;

        playerInventory.HealInfo();
    }

    private void HealText()
    {
        if (healDuration <= 0)
            healDuration = 0;
        else
        healDuration -= 0.001f;
    }
}
