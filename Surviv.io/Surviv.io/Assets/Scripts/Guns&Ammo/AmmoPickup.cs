using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    public GunType gun;
    public Inventory playerInventory;

    private void Awake()
    {
        playerInventory = GameObject.Find("Player").GetComponent<Inventory>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if(gun == GunType.Handgun)
            {
                HandgunAmmo();
            }
            else if (gun == GunType.Shotgun)
            {
                ShotgunAmmo();
            }
            else if (gun == GunType.Rifle)
            {
                RifleAmmo();
            }
            Destroy(gameObject);
        }
    }


    void HandgunAmmo()
    {
        Debug.Log("20 9mm");
        playerInventory.Inventory_HandgunAmmo += 20;
        playerInventory.AmmoInfo();
    }

    void ShotgunAmmo()
    {
        Debug.Log("16 12gauge");
        playerInventory.Inventory_ShotgunAmmo += 16;
        playerInventory.AmmoInfo();
    }

    void RifleAmmo()
    {
        Debug.Log("30 5.56rounds");
        playerInventory.Inventory_RifleAmmo += 30;
        playerInventory.AmmoInfo();
    }
}
