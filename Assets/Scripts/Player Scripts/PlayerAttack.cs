using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private WeaponManager weapon_Manager;

    public float fireRate = 15f;
    private float nextTimeToFire;
    public float damage = 20f;


    void Awake()
    {
        weapon_Manager = GetComponent<WeaponManager>();
    }


    // Update is called once per frame
    void Update()
    {
        WeaponShoot();
    }

    void WeaponShoot()
    {
        if (Input.GetMouseButtonDown(0) == true && weapon_Manager.GetCurrentSelectedWeapon().tag == Tags.AXE_TAG)
        {
            weapon_Manager.GetCurrentSelectedWeapon().ShootAnimation();
        }
    }
}
