using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPickUp : MonoBehaviour
{
    public GunType gun;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerShoot playerShoot = collision.GetComponent<PlayerShoot>();
        Inventory playerInventory = collision.GetComponent<Inventory>();

        if (playerShoot != null)
        {
            playerShoot.guntype = gun;
            Equip(gun, playerInventory);
            Destroy(gameObject);
        }
    }

    private void Equip(GunType guntype, Inventory playerInventory)
    {
        Debug.Log($"{guntype.ToString()} equipped");
        playerInventory.PickedUpWeapon = guntype;
        playerInventory.EquipInfo();
        PickedGun(playerInventory);
    }

    private void PickedGun(Inventory playerInventory)
    {
        if (gun == GunType.Rifle) playerInventory.hasRifle = true;
        if (gun == GunType.Shotgun) playerInventory.hasShotgun = true;
    }
}
