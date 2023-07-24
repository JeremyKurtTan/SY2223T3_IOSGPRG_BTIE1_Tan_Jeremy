using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Inventory : MonoBehaviour 
{
    [SerializeField] private PlayerShoot playergun;
    public GunType PickedUpWeapon;

    public bool hasShotgun;
    public bool hasRifle;

    public Shotgun shotty;
    public Pistol pistol;
    public Rifle rifle;

    public int Inventory_HandgunAmmo;
    public int Inventory_ShotgunAmmo;
    public int Inventory_RifleAmmo;   

    public TMP_Text HandgunAmmoInfo;
    public TMP_Text ShotgunAmmoInfo;
    public TMP_Text RifleAmmoInfo;
    public TMP_Text WeaponEquipInfo;

    private void Awake()
    {
        hasShotgun = false;
        hasRifle = false;
    }
    public void AmmoInfo()
    {
       HandgunAmmoInfo.text = "9mm: " + pistol.currentAmmo.ToString() + " / " + Inventory_HandgunAmmo.ToString();
       Inventory_HandgunAmmo = Mathf.Min(Inventory_HandgunAmmo, 45);
       ShotgunAmmoInfo.text = "12Gauge: " + shotty.currentAmmo.ToString() + " / " + Inventory_ShotgunAmmo.ToString();
       Inventory_ShotgunAmmo = Mathf.Min(Inventory_ShotgunAmmo, 36);
       RifleAmmoInfo.text = "5.56Rounds: " + rifle.currentAmmo.ToString() + " / " + Inventory_RifleAmmo.ToString();
       Inventory_RifleAmmo = Mathf.Min(Inventory_RifleAmmo, 150);
    }

    public void EquipInfo()
    {
        playergun.WeaponEquip();
        WeaponEquipInfo.text = "Weapon: " + PickedUpWeapon.ToString();
    }

    public void WeaponSwitching()
    {
        if(playergun.guntype != GunType.Rifle && hasRifle == true)
        {
            playergun.guntype = GunType.Rifle;
            playergun.WeaponEquip();
        }
        else if (playergun.guntype != GunType.Shotgun && hasShotgun == true)
        {
            playergun.guntype = GunType.Shotgun;
            playergun.WeaponEquip();
        }
    }
}
