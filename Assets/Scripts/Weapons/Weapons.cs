using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    public float fireRate; //Shots per minute
    protected float fireTimer;

    void Update()
    {
        fireTimer += Time.deltaTime;
    }

    public virtual void Use()
    {
        if (fireTimer <= 60 / fireRate)
        {
            return;
        }
        print("Bang");
        fireTimer = 0;
    }
}
