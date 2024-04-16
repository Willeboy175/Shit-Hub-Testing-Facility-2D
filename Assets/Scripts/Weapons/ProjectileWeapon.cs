using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileWeapon : RangedWeapon
{
    public GameObject projectile;
    protected GameObject newestProjectile;

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    }

    public override bool Use()
    {
        if (base.Use() == false)
        {
            return false;
        }
        newestProjectile = Instantiate(projectile, transform.position, Quaternion.identity);
        newestProjectile.transform.up = dir;
        return true;
    }
}
