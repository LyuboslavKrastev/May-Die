using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int _hitPoints = 600;

    public bool IsDead { get; private set; }

    public void TakeDamage(int damage)
    {
        _hitPoints -= damage;
        if (_hitPoints < 1 && IsDead == false)
        {
            Die();
        }
        BroadcastMessage("OnDamageTaken"); // at the moement such a method only exists within the EnemyAI class
    }

    private void Die()
    {
        IsDead = true;
        GetComponent<Animator>().SetTrigger("die");
        Destroy(gameObject, 10f);
    }
}
