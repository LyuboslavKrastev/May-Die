using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    [SerializeField] private int _currentWeaponIndex = 0;
    public int BLUEROSE_INDEX { get; private set; }
    public int REDQUEEN_INDEX { get; private set; }
    public int EBONYANDIVORY_INDEX { get; private set; }
    void Start()
    {
        ActivateWeapon();
    }

    private void ActivateWeapon()
    {
        int weaponIndex = 0;

        foreach (Transform weapon in transform)
        {
            if (weaponIndex == _currentWeaponIndex)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }

            IndexWeapons(weaponIndex, weapon);

            weaponIndex++;
        }
    }

    private void IndexWeapons(int weaponIndex, Transform weapon)
    {
        switch (weapon.tag)
        {
            case "Blue Rose":
                BLUEROSE_INDEX = weaponIndex;
                break;
            case "Red Queen":
                REDQUEEN_INDEX = weaponIndex;
                break;
            case "Ebony and Ivory":
                EBONYANDIVORY_INDEX = weaponIndex;
                break;
            default:
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        int previousWeaponIndex = _currentWeaponIndex;

        ProcessKeyInput();
        ProcessScrollWheel();

        if (previousWeaponIndex != _currentWeaponIndex)
        {
            ActivateWeapon();
        }
    }
    private void ProcessKeyInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _currentWeaponIndex = BLUEROSE_INDEX;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _currentWeaponIndex = REDQUEEN_INDEX;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            _currentWeaponIndex = EBONYANDIVORY_INDEX;
        }
    }

    private void ProcessScrollWheel()
    {
        if (Input.GetAxis("Mouse ScrollWheel") < 0) // down on the scrollwheel
        {
            if (_currentWeaponIndex >= transform.childCount - 1)
            {
                _currentWeaponIndex = 0;
            }
            else
            {
                _currentWeaponIndex++;
            }
        }
        else if (Input.GetAxis("Mouse ScrollWheel") > 0) // up on the scrollwheel
        {
            if (_currentWeaponIndex <= 0)
            {
                _currentWeaponIndex = transform.childCount - 1;
            }
            else
            {
                _currentWeaponIndex--;
            }
        }
    }
}
