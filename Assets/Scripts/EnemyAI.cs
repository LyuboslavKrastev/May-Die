using System;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [Tooltip("In meters")] [SerializeField] private float _aggroRange = 10f;

    private float _distanceToTarget = Mathf.Infinity;

    private NavMeshAgent _navMeshAgent;

    private bool _isProvoked = false;
    
    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();

        if (_navMeshAgent == null)
        {
            Debug.LogError("NavMeshAgent is NULL!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        _distanceToTarget = Vector3.Distance(_target.position, transform.position);
        if (_isProvoked)
        {
            EngageTarget();
        }
        else if (_distanceToTarget <= _aggroRange)
        {
            _isProvoked = true;
        }
    }

    private void EngageTarget()
    {
        if (_distanceToTarget > _navMeshAgent.stoppingDistance)
        {
            ChaseTarget();
        }
        else
        {
            AttackTarget();
        }
    }

    private void AttackTarget()
    {
        print("Attacking!");
    }

    private void ChaseTarget()
    {
        _navMeshAgent.SetDestination(_target.position);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(transform.position, _aggroRange);
    }
}
