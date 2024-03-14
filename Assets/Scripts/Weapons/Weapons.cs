using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    public float fireRate;

    public virtual void Use()
    {
        print("Bang");
    }
}
