using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Ammo : MonoBehaviour
{
    [SerializeField] private int _ammoAmount;

    private string weaponName;
    public int AmmoAmount
    {
        get
        {
            return _ammoAmount;
        }
        set
        {
            _ammoAmount = value;
        }
    }

    [SerializeField] private TextMeshProUGUI _ammoText;


    void Awake()
    {
        weaponName = gameObject.tag;
        UpdateAmmoText();
    }

    public void ReduceAmmo()
    {
        AmmoAmount -= 1;
        UpdateAmmoText();
    }

    public void IncreaseAmmo(int amount)
    {
        AmmoAmount += amount;
        UpdateAmmoText();
    }

    public void UpdateAmmoText()
    {
        _ammoText.text = $"{weaponName}: {_ammoAmount}";
    }
}

