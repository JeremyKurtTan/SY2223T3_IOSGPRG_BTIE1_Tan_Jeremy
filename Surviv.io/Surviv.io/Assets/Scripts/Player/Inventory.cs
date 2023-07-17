using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Inventory : MonoBehaviour 
{
    [SerializeField] PlayerShoot playergun;
    public string PickedUpWeapon;

    public int Inventory_HandgunAmmo;
    public int Inventory_ShotgunAmmo;
    public int Inventory_RifleAmmo;

    public TMP_Text HandgunAmmoInfo;
    public TMP_Text ShotgunAmmoInfo;
    public TMP_Text RifleAmmoInfo;
    public TMP_Text WeaponEquipInfo;



    public void AmmoInfo()
    {
       HandgunAmmoInfo.text = "9mm: " +   "0 / " + Inventory_HandgunAmmo.ToString();
       Inventory_HandgunAmmo = Mathf.Min(Inventory_HandgunAmmo, 45);
       ShotgunAmmoInfo.text = "12Gauge: " + "0 / " + Inventory_ShotgunAmmo.ToString();
       Inventory_ShotgunAmmo = Mathf.Min(Inventory_ShotgunAmmo, 36);
       RifleAmmoInfo.text = "5.56Rounds: " +  "0 / " + Inventory_RifleAmmo.ToString();
       Inventory_RifleAmmo = Mathf.Min(Inventory_RifleAmmo, 150);
    }
    public void EquipInfo()
    {
        WeaponEquipInfo.text = "Weapon: " + PickedUpWeapon;
    }
}
