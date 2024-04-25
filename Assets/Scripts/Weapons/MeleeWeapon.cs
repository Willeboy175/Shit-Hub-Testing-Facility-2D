using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeleeWeapon : Weapons
{
    public float range = 1.4f;
    public LayerMask mask;

    protected Vector3 startPos;
    protected Vector3 endPos;

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, range);
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();

        if (Use() == true)
        {

        }
        else
        {
            weapon.transform.up = dir;
        }
    }

    public override bool Use()
    {
        if (base.Use() == false)
        {
            return false;
        }

        Collider2D collider = Physics2D.OverlapCircle(transform.position, range, mask);

        if (collider != null)
        {
            print("Hit");

            Destroy(collider.gameObject);
        }

        return true;
    }
}
