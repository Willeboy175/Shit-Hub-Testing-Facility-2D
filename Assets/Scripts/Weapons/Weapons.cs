using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    [Tooltip("Attacks per minute")]
    public float attackSpeed; //Attacks per minute
    public string weaponName;

    float currentTime;
    protected Vector2 dir;

    public virtual void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        dir = (mousePos - transform.position).normalized;

        currentTime += Time.deltaTime;
    }

    public virtual bool Use()
    {
        if (currentTime <= 60 / attackSpeed)
        {
            return false;
        }
        currentTime = 0;
        print("Bang");
        return true;
    }
}
