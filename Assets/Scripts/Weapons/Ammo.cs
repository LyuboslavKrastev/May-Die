using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Ammo : MonoBehaviour
{
    [SerializeField] private int _ammoAmount;
    private const int CLIP_SIZE = 1000;
    public int AmmoAmount
    {
        get
        {
            return _ammoAmount;
        }
        set
        {
            _ammoAmount = value;
            _ammoText.text = $"Ammo: {_ammoAmount}";
        }
    }

    [SerializeField] private TextMeshProUGUI _ammoText;

    void Start()
    {
        AmmoAmount = CLIP_SIZE;
    }

    public void ReduceAmmo()
    {
        AmmoAmount -= 1;
    }
}
