using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Gun
{
    private void Awake()
    {
        currentAmmo = 16;
        maxAmmo = 16;
    }
    public override void Shoot()
    {
        base.Shoot();
        Debug.Log("Pew  x5 ");
    }
}
