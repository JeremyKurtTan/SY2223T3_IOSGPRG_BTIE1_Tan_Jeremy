using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInventory : MonoBehaviour 
{
    public string PickedUpWeapon;
    public int CurrentHandgunAmmo;
    public int CurrentShotgunAmmo;
    public int CurrentRifleAmmo;

    private int MaxHandgunAmmo = 40;
    private int MaxShotgunAmmo = 32;
    private int MaxRifleAmmo = 150;

    public TMP_Text HandgunAmmoInfo;
    public TMP_Text ShotgunAmmoInfo;
    public TMP_Text RifleAmmoInfo;
    public TMP_Text WeaponEquipInfo;

    private void Start()
    {
        CurrentHandgunAmmo = 0;
        CurrentShotgunAmmo = 0;
        CurrentRifleAmmo = 0;
    }
    private void Update()
    {
        if(CurrentHandgunAmmo >= MaxHandgunAmmo)
        {
            CurrentHandgunAmmo = MaxHandgunAmmo;
        }
        if (CurrentShotgunAmmo >= MaxShotgunAmmo)
        {
            CurrentShotgunAmmo = MaxShotgunAmmo;
        }
        if(CurrentRifleAmmo >= MaxRifleAmmo)
        {
            CurrentRifleAmmo = MaxRifleAmmo;
        }
    }
    public void AmmoInfo()
    {
        HandgunAmmoInfo.text = "9mm: " + CurrentHandgunAmmo.ToString() + " / 40";
        ShotgunAmmoInfo.text = "12Gauge: " + CurrentShotgunAmmo.ToString() + " / 32";
        RifleAmmoInfo.text = "5.56Rounds: " + CurrentRifleAmmo.ToString() + " / 150";
    }

    public void EquipInfo()
    {
        WeaponEquipInfo.text = "Weapon: " + PickedUpWeapon;
    }
}
