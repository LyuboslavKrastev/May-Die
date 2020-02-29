using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int _hitPoints = 1500;
    

    public void TakeDamage(int damage)
    {
        if (_hitPoints < 1)
        {
            Destroy(this.gameObject);
        }
        _hitPoints -= damage;
        BroadcastMessage("OnDamageTaken"); // at the moement such a method only exists within the EnemyAI class
    }
}
