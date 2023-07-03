using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Type
{ 
    Handgun,
    Shotgun,
    Rifle
}

public class GunType : MonoBehaviour
{
    private Type gunType;

    private float fireRate;
    private float firingError;
}
