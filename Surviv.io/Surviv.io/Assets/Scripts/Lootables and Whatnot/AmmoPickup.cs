using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    public GunType gun;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Inventory playerInventory = collision.gameObject.GetComponent<Inventory>();
        if (playerInventory != null)
        {
            if(gun == GunType.Handgun)
            {
                GunAmmo(playerInventory, 10, 0 ,0, 0);
            }
            else if (gun == GunType.Shotgun)
            {
                GunAmmo(playerInventory, 0, 16, 0, 0);
            }
            else if (gun == GunType.Rifle)
            {
                GunAmmo(playerInventory, 0, 0, 30, 0);
            }
            else if (gun == GunType.GrenadeLauncher)
            {
                GunAmmo(playerInventory, 0, 0, 0, 10);
            }
            Destroy(gameObject);
        }
    }

    void GunAmmo(Inventory playerInventory, int handgunammopickup, int shotgunammopickup, int rifleammopickup, int rocketlauncherammopickup)
    {
        playerInventory.Inventory_RifleAmmo += rifleammopickup;
        playerInventory.Inventory_ShotgunAmmo += shotgunammopickup;
        playerInventory.Inventory_HandgunAmmo += handgunammopickup;
        playerInventory.Inventory_RocketLauncherAmmo += rocketlauncherammopickup;
        playerInventory.AmmoInfo();
    }
}
