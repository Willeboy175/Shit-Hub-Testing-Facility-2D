using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponHandler : MonoBehaviour
{
    public Weapons[] weapons;

    private int currentWeapon;
    private int lowerBoundWeapons;
    private int upperBoundWeapons;

    // Start is called before the first frame update
    void Start()
    {
        weapons = GetComponents<Weapons>();

        print(weapons.GetLowerBound(lowerBoundWeapons) + ", " + weapons.GetUpperBound(upperBoundWeapons));
        print(currentWeapon + ", " + weapons[currentWeapon].weaponName);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            weapons[currentWeapon].Use();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            weapons[currentWeapon].weapon.SetActive(false);

            currentWeapon++;

            if (currentWeapon >= weapons.Length)
            {
                currentWeapon = 0;
            }

            weapons[currentWeapon].weapon.SetActive(true);
            print(currentWeapon + ", " + weapons[currentWeapon].weaponName);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            weapons[currentWeapon].weapon.SetActive(false);
            currentWeapon--;

            if (currentWeapon <= -1)
            {
                currentWeapon = weapons.Length - 1;
            }

            weapons[currentWeapon].weapon.SetActive(true);
            print(currentWeapon + ", " + weapons[currentWeapon].weaponName);
        }
    }
}
