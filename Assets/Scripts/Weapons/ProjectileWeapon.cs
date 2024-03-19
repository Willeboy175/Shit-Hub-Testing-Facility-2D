using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileWeapon : RangedWeapon
{
    public float speed;
    public float lifeTime;
    public Vector2 dir;
    public GameObject prefabProjectile;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        fireTimer += Time.deltaTime;
    }

    public override void Use()
    {
        base.Use();

        GameObject projectile = Instantiate(prefabProjectile, transform);
        PlayerProjectile playerProjectile = projectile.GetComponent<PlayerProjectile>();

        playerProjectile.speed = speed;
        playerProjectile.lifeTime = lifeTime;
        playerProjectile.dir = dir;
    }
}
