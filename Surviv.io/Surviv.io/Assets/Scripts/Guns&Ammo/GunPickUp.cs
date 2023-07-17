using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPickUp : MonoBehaviour
{
    public GunType gun;
    Gun equipGun;
    PlayerShoot playerShoot;

    public Inventory playerInventory;
    private void Awake()
    {
        playerShoot = GameObject.Find("Player").GetComponent<PlayerShoot>();
        playerInventory = GameObject.Find("Player").GetComponent<Inventory>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (gun == GunType.Handgun)
            {
                playerShoot.guntype = GunType.Handgun;
                EquipHandgun();
            }
            else if (gun == GunType.Shotgun)
            {
                playerShoot.guntype = GunType.Shotgun;
                EquipShotgun();
            }
            else if (gun == GunType.Rifle)
            {
                playerShoot.guntype = GunType.Rifle;
                EquipRifle();
            }
            Destroy(gameObject);
        }
    }
        
    void EquipHandgun()
    {
        Debug.Log("Handgun equipped");
        playerInventory.PickedUpWeapon = "Handgun";
        playerInventory.EquipInfo();
    }

    void EquipShotgun()
    {
        Debug.Log("Shotgun equipped");
        playerInventory.PickedUpWeapon = "Shotgun";
        playerInventory.EquipInfo();
    }

    void EquipRifle()
    {
        Debug.Log("Rifle equipped");
        playerInventory.PickedUpWeapon = "Rifle";
        playerInventory.EquipInfo();
    }
}
