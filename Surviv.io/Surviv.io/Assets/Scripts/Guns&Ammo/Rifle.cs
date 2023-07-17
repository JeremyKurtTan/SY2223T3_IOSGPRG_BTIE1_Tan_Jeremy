using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : Gun
{
    private void Awake()
    {
        currentAmmo = 30;
        maxAmmo = 30;
    }
    public override void Shoot()
    {
        base.Shoot();
        Debug.Log("PewPewPewPew");
    }
}
