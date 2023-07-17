using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Gun
{
    private void Awake()
    {
        currentAmmo = 10;
        maxAmmo = 10;
    }
    public override void Shoot()
    {
        if (currentAmmo > 0)
        {
            base.Shoot();
            Debug.Log("Pew");
        }
        else
            return;
    }
}
