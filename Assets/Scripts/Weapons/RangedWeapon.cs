using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedWeapon : Weapons
{
    public int ammo;
    public float reloadSpeed;

    protected int currentAmmo;
    protected float reloadTimer;

    // Update is called once per frame
    void Update()
    {
        fireTimer += Time.deltaTime;

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

    public override void Use()
    {
        base.Use();
        if (currentAmmo <= 0)
        {
            print("No ammo");
            return;
        }
        currentAmmo--;
        print("Shoot! ammo remaining: " + currentAmmo);
    }
}
