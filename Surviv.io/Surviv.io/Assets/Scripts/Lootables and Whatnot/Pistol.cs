using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Gun
{
    private void Awake()
    {
        currentAmmo = 0;
        maxAmmo = 10;
        originalfirerate = 0.55f;
    }

    public override void Shoot()
    {
        base.Shoot();
    }

    public override void Reload()
    {
        if (ammoCheck.Inventory_HandgunAmmo <= 0)
            return;
        else
        {
            base.Reload();
            ammoCheck.Inventory_HandgunAmmo -= currentAmmo;
        }
    }
}
