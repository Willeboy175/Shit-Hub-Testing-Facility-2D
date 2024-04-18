using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitscanWeapon : RangedWeapon
{
    public float range = 5f;
    public LayerMask mask;
    public GameObject laser;
    public LineRenderer lineRenderer;

    protected Vector3 startPos;
    protected Vector3 endPos;
    protected GameObject newestLaser;

    public override bool Use()
    {
        if (base.Use() == false)
        {
            return false;
        }

        RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, range, mask);

        startPos = transform.position;
        endPos = transform.position + new Vector3(dir.x, dir.y, 0) * range;

        if (hit.collider)
        {
            print("Hitting: " + hit.transform.name);

            lineRenderer.SetPosition(0, startPos);
            lineRenderer.SetPosition(1, hit.point);

            if (hit.collider.CompareTag("Enemy"))
            {
                print("Hit Enemy");

                Destroy(hit.transform.gameObject);
            }
        }
        else
        {
            lineRenderer.SetPosition(0, startPos);
            lineRenderer.SetPosition(1, endPos);
        }

        

        //newestLaser = Instantiate(laser, transform.position, Quaternion.identity);
        //newestLaser.transform.up = dir;
        //newestLaser.transform.localPosition = hit.point / 2;
        //newestLaser.transform.localScale = hit.point;

        return true;
    }
}