using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPickUp : MonoBehaviour
{
    public Type gun;

    public PlayerInventory playerInventory;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (gun == Type.Handgun)
            {
                EquipHandgun();
            }
            else if (gun == Type.Shotgun)
            {
                EquipShotgun();
            }
            else if (gun == Type.Rifle)
            {
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
