using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitscanWeapon : RangedWeapon
{
    public float range = 3f;
    public LayerMask mask;
    public GameObject laser;

    public override bool Use()
    {
        if (base.Use() == false)
        {
            return false;
        }

        RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, range, mask);

        if (hit.collider)
        {
            print("Hitting: " + hit.transform.name);

            if (hit.collider.CompareTag("Enemy"))
            {
                print("Hit Enemy");

                Destroy(hit.transform.gameObject);
            }
        }



        return true;
    }
}
