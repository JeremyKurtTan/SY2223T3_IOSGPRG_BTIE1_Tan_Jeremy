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

    public bool Waiting = false;

    public virtual void Shoot()
    {
        ammoCheck.AmmoInfo();
        if (currentAmmo > 0)
        {
            if(!Waiting)
            {
                if (currentfirerate <= 0)
                {
                    Instantiate(bullet, bulletspawnPoint.transform.position, bulletspawnPoint.transform.rotation);
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

    public void EnemyShoot()
    {
         if (!Waiting)
            if (currentfirerate <= 0)
            {
                Instantiate(bullet, bulletspawnPoint.transform.position, bulletspawnPoint.transform.rotation);
                currentAmmo--;
                currentfirerate = originalfirerate;
            }
            else
                StartCoroutine(Delay());

        if (currentAmmo > 0)
            return;
        else
            StartCoroutine(EnemyReload());
    }
    public virtual void Reload()
    {
        Debug.Log("Ammo");
        currentAmmo = maxAmmo;
        ammoCheck.AmmoInfo();
    }

    private IEnumerator Delay()
    {
        Waiting = true;
        yield return new WaitForSeconds(currentfirerate);
        currentfirerate = 0;
        Waiting = false ;
    }

    private IEnumerator EnemyReload()
    {
        currentAmmo = maxAmmo;
        Waiting = true;
        yield return new WaitForSeconds(1.5f);
        Waiting = false;
    }
}
