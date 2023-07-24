using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Gun
{
    public GameObject ShotgunSpawn1;
    public GameObject ShotgunSpawn2;

    private void Awake()
    {
        currentAmmo = 0;
        maxAmmo = 16;
        originalfirerate = 1f;
    }

    public override void Shoot()
    {
        if (!Waiting)
        {
            base.Shoot();
            if (currentfirerate <= 0)
            {
                Instantiate(bullet, ShotgunSpawn1.transform.position, Quaternion.identity);
                Instantiate(bullet, ShotgunSpawn2.transform.position, Quaternion.identity);
            }
        }
    }

    public override void Reload()
    {
        if (ammoCheck.Inventory_ShotgunAmmo <= 0)
            return;
        else
        {
            base.Reload();
            ammoCheck.Inventory_ShotgunAmmo -= currentAmmo;
        }
    }
}
