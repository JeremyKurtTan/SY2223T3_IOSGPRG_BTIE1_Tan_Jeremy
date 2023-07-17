using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GunType
{ 
    Handgun,
    Shotgun,
    Rifle
}

public class Gun : MonoBehaviour
{
    private GunType gunType;
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject bulletspawnPoint;
    [SerializeField] float firerate;
    private float firingError;

    public int currentAmmo = 0;
    public  int maxAmmo = 10;

    private void Awake()
    {
        currentAmmo = maxAmmo;
    }
    public virtual void Shoot()
    {
        Debug.Log(currentAmmo);
        if (currentAmmo > 0)
        {
            Instantiate(bullet, bulletspawnPoint.transform.position, Quaternion.identity);
            currentAmmo--;
        }
    }

    public void ReloadGun()
    {
        Debug.Log("Reloading");
        Invoke("Reload", 1.5f);
    }

    void Reload()
    {
        Debug.Log("Ammo");
        currentAmmo = maxAmmo;
    }
}
