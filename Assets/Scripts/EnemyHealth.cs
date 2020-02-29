using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int _hitPoints = 100;
    

    public void TakeDamage(int damage)
    {
        _hitPoints -= damage;
    }
}
