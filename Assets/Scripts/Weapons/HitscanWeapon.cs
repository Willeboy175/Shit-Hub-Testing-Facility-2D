using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitscanWeapon : RangedWeapon
{
    public float range = 5f;
    public float laserduration = 1f;
    public LayerMask mask;
    public LineRenderer lineRenderer;

    protected float laserTimer;
    protected Vector3 startPos;
    protected Vector3 endPos;

    public override void Update()
    {
        base.Update();

        laserTimer += Time.deltaTime;

        if (laserTimer >= laserduration)
        {
            lineRenderer.SetPosition(0, startPos);
            lineRenderer.SetPosition(1, startPos);
        }
    }

    public override bool Use()
    {
        if (base.Use() == false)
        {
            return false;
        }

        RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, range, mask);

        startPos = transform.position;
        endPos = transform.position + new Vector3(dir.x, dir.y, 0) * range;
        laserTimer = 0;

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

        return true;
    }
}