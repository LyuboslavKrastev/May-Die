using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    [SerializeField] private int _currentWeaponIndex = 0;

    private const int BLUEROSE_INDEX = 0;
    private const int REDQUEEN_INDEX = 1;
    private const int EBONYANDIVORY_INDEX = 2;
    void Start()
    {
        ActivateWeapon();
    }

    private void ActivateWeapon()
    {
        int weaponIndex = 0;
        Debug.Log("Looping");

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

            weaponIndex++;
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
            if (_currentWeaponIndex < 0)
            {
                _currentWeaponIndex = transform.childCount -1;
            }
            else
            {
                _currentWeaponIndex--;
            }
        }
    }
}
