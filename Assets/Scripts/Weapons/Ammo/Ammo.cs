using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Ammo : MonoBehaviour
{
    [SerializeField] private int _ammoAmount;
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

    public void ReduceAmmo()
    {
        AmmoAmount -= 1;
        UpdateAmmoText();
    }

    public void UpdateAmmoText()
    {
        _ammoText.text = $"Ammo:  {_ammoAmount}";
    }
}

