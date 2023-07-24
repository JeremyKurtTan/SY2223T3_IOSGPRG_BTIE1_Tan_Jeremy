using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public Gun gun;
    public GunType guntype;

    public GameObject Pistol;
    public GameObject Shotgun;
    public GameObject Rifle;

    bool isShooting;

    public void WeaponEquip()
    {
        if (guntype == GunType.Handgun)
        {
            Pistol.SetActive(true);
            Shotgun.SetActive(false);
            Rifle.SetActive(false);
            gun = Pistol.GetComponent<Pistol>();
        }
        else if (guntype == GunType.Shotgun)
        {
            Pistol.SetActive(false);
            Shotgun.SetActive(true);
            Rifle.SetActive(false);
            gun = Shotgun.GetComponent<Shotgun>();
        }
        else if (guntype == GunType.Rifle)
        {
            Pistol.SetActive(false);
            Rifle.SetActive(true);
            Shotgun.SetActive(false);
            gun = Rifle.GetComponent<Rifle>();
        }
    }

    private void Update()
    {
        if(isShooting == true)
            gun.Shoot();
    }

    public void FireGun(bool shoot)
    {
        if(gun != null)
        isShooting = shoot;
    }

    public void ReloadGun()
    {
        if (gun != null)
            gun.ReloadGun();
    }

}
