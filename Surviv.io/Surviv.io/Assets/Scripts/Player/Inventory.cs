using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Inventory : MonoBehaviour 
{
    [SerializeField] private PlayerShoot playergun;
    [SerializeField] private Stimpack stimpack;
    public GunType PickedUpWeapon;

    public bool hasShotgun;
    public bool hasRifle;
    public bool hasRocketLauncher;

    public Shotgun shotty;
    public Pistol pistol;
    public Rifle rifle;
    public RocketLauncher rocketLauncher;

    public int Inventory_HandgunAmmo;
    public int Inventory_ShotgunAmmo;
    public int Inventory_RifleAmmo;   
    public int Inventory_RocketLauncherAmmo;
    public int Inventory_StimpackAmount;

    public TMP_Text HandgunAmmoInfo;
    public TMP_Text ShotgunAmmoInfo;
    public TMP_Text RifleAmmoInfo;
    public TMP_Text RocketLauncherAmmoInfo;

    public TMP_Text WeaponEquipInfo;
    public TMP_Text StimpackInfo;

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
       RocketLauncherAmmoInfo.text = "40mm: " + rocketLauncher.currentAmmo.ToString() + " / " + Inventory_RocketLauncherAmmo.ToString();
       Inventory_RocketLauncherAmmo = Mathf.Min(Inventory_RocketLauncherAmmo, 10);
    }

    public void HealInfo()
    {
        StimpackInfo.text = "Stimpacks: " + Inventory_StimpackAmount.ToString();
    }

    public void EquipInfo()
    {
        playergun.WeaponEquip();
        WeaponEquipInfo.text = "Weapon: " + PickedUpWeapon.ToString();
    }

    public void WeaponSwitching()
    {
        if (hasRocketLauncher)
            return;

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
