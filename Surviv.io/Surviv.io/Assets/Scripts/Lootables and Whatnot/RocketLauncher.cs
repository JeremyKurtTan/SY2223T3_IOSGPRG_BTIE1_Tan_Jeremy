using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLauncher : Gun
{
    private void Awake()
    {
        currentAmmo = 0;
        maxAmmo = 1;
        originalfirerate = 2.5f;
    }

    public override void Shoot()
    {
        base.Shoot();
    }

    public override void Reload()
    {
        if (ammoCheck.Inventory_RocketLauncherAmmo <= 0)
            return;
        else
        {
            base.Reload();
            ammoCheck.Inventory_RocketLauncherAmmo -= currentAmmo;
        }
    }
}
