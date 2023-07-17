using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : Unit
{
    [SerializeField] Gun gun;
    public GunType guntype;

    public GameObject Pistol;
    public GameObject Shotgun;
    public GameObject Rifle;
    private void Update()
    {
        if(guntype == GunType.Handgun)
        {
            Pistol.SetActive(true);
            Shotgun.SetActive(false);
            Rifle.SetActive(false);
            gun = GameObject.Find("Pistol").GetComponent<Pistol>();
        }
        else if (guntype == GunType.Shotgun)
        {
            Pistol.SetActive(false);
            Shotgun.SetActive(true);
            Rifle.SetActive(false);
            gun = GameObject.Find("Shotgun").GetComponent<Shotgun>();
        }
        else if (guntype == GunType.Rifle)
        {
            Pistol.SetActive(false);
            Rifle.SetActive(true);
            Shotgun.SetActive(false);
            gun = GameObject.Find("AutomaticRifle").GetComponent<Rifle>();
        }
    }
    public void FireGun()
    {
        if(gun != null)
            gun.Shoot();
    }

    public void ReloadGun()
    {
        if (gun != null)
            gun.ReloadGun();
    }

}
