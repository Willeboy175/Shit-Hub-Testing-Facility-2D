using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedWeapon : Weapons
{
    public int ammo;
    public float reloadSpeed;

    int currentAmmo;
    float reloadTimer;

    // Update is called once per frame
    public override void Update()
    {
        base.Update();

        if (currentAmmo <= 0 || Input.GetKeyDown(KeyCode.R))
        {
            reloadTimer += Time.deltaTime;
            if (reloadTimer > reloadSpeed)
            {
                currentAmmo = ammo;
                reloadTimer = 0;
            }
        }
    }

    public override bool Use()
    {
        if (currentAmmo <= 0 || base.Use() == false)
        {
            print("No ammo");
            return false;
        }
        currentAmmo--;
        print("Shoot! ammo remaining: " + currentAmmo);
        return true;
    }
}
