using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : Gun
{
    private void Awake()
    {
        currentAmmo = 0;
        maxAmmo = 30;
        originalfirerate = 0.2f;
    }

    public override void Shoot()
    {
        base.Shoot();
    }

    public override void Reload()
    {
        if (ammoCheck.Inventory_RifleAmmo <= 0)
            return;
        else
        {
            base.Reload();
            ammoCheck.Inventory_RifleAmmo -= currentAmmo;
        }
    }
}
