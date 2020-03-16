using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [Tooltip("In meters")] [SerializeField] private float _aggroRange = 10f;
    [SerializeField] private float _turnSpeed = 5f;

    private float _distanceToTarget = Mathf.Infinity;

    private NavMeshAgent _navMeshAgent;

    private bool _isProvoked = false;

    private EnemyHealth _health;

    private AudioSource _moveSound;
    
    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        NullAlerter.AlertIfNull(_navMeshAgent, nameof(_navMeshAgent));

        _health = GetComponent<EnemyHealth>();
        NullAlerter.AlertIfNull(_health, nameof(_health));

        _moveSound = GetComponent<AudioSource>();
        NullAlerter.AlertIfNull(_moveSound, nameof(_moveSound));
    }

    // Update is called once per frame
    void Update()
    {
        if (_health.IsDead == true)
        {
            _navMeshAgent.enabled = false;
            GetComponent<Collider>().enabled = false;
            StopMovingSound();
            enabled = false;
            return;
        }

        _distanceToTarget = Vector3.Distance(_target.position, transform.position);
        if (_isProvoked)
        {
            EngageTarget();
            PlayMovingSound();
        }
        else if (_distanceToTarget <= _aggroRange)
        {
            _isProvoked = true;
        }
    }

    private void PlayMovingSound()
    {
        if (!_moveSound.isPlaying)
        {
            _moveSound.Play();
        }
    }
    private void StopMovingSound()
    {
        _moveSound.Stop();
    }

    private void EngageTarget()
    {
        FaceTarget();
        if (_distanceToTarget > _navMeshAgent.stoppingDistance)
        {
            ChaseTarget();
        }
        else
        {
            AttackTarget();
        }
    }

    private void OnDamageTaken()
    {
        _isProvoked = true;
    }

    private void AttackTarget()
    {
        StopMovingSound();
        Animator animator = GetComponent<Animator>();
        NullAlerter.AlertIfNull(animator, nameof(animator));
        animator.SetBool("attack", true);
    }

    private void ChaseTarget()
    {
        Animator animator = GetComponent<Animator>();
        if (animator == null)
        {
            Debug.LogError("Animator is NULL!");
        }
        else
        {
            animator.SetBool("attack", false);
            animator.SetTrigger("move");
        }
        _navMeshAgent.SetDestination(_target.position);
    }

    private void FaceTarget()
    {
        Vector3 direction = (_target.position - transform.position).normalized;

        // Z axis will be aligned with forward, X axis aligned with cross product between forward and upwards, and Y axis aligned with cross product between Z and X.
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));

        // Slerp - rotation which smoothly interpolates between the first quaternion (a) to the second quaternion (a
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * _turnSpeed);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(transform.position, _aggroRange);
    }
}
