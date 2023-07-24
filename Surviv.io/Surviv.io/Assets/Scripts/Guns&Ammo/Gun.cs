using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum GunType
{ 
    Handgun,
    Shotgun,
    Rifle
}

public class Gun : MonoBehaviour
{
    public Inventory ammoCheck;
    private GunType gunType;
    public GameObject bullet;
    public GameObject bulletspawnPoint;
    
    private float firingError;

    public float originalfirerate = 1;
    public float currentfirerate = 0;
    public int currentAmmo = 0;
    public int maxAmmo = 0;

    public bool Waiting;

    public virtual void Shoot()
    {
        ammoCheck.AmmoInfo();
        if (currentAmmo > 0)
        {
            if(!Waiting)
            {
                if (currentfirerate <= 0)
                {
                    Instantiate(bullet, bulletspawnPoint.transform.position, Quaternion.identity);
                    currentAmmo--;
                    currentfirerate = originalfirerate;
                }
                else
                    StartCoroutine(Delay());
            }
        }
    }

    public void ReloadGun() //Button
    {
        Debug.Log("Reloading");
        Invoke("Reload", 1.5f);
    }

    public virtual void Reload()
    {
        ammoCheck.AmmoInfo();
        Debug.Log("Ammo");
        currentAmmo = maxAmmo;
    }

    IEnumerator Delay()
    {
        Waiting = true;
        yield return new WaitForSeconds(currentfirerate);
        currentfirerate = 0;
        Waiting = false ;
    }
}
