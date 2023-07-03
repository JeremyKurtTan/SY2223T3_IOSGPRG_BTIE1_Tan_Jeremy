using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    public Type gun;

    public PlayerInventory playerInventory;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if(gun == Type.Handgun)
            {
                HandgunAmmo();
            }
            else if (gun == Type.Shotgun)
            {
                ShotgunAmmo();
            }
            else if (gun == Type.Rifle)
            {
                RifleAmmo();
            }
            Destroy(gameObject);
        }
    }


    void HandgunAmmo()
    {
        Debug.Log("20 9mm");
        playerInventory.CurrentHandgunAmmo += 20;
        playerInventory.AmmoInfo();
    }

    void ShotgunAmmo()
    {
        Debug.Log("16 12gauge");
        playerInventory.CurrentShotgunAmmo += 16;
        playerInventory.AmmoInfo();
    }

    void RifleAmmo()
    {
        Debug.Log("30 5.56rounds");
        playerInventory.CurrentRifleAmmo += 30;
        playerInventory.AmmoInfo();
    }
}
