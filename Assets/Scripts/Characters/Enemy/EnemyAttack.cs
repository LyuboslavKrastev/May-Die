using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private int _damage = 25;

    private PlayerHealth _playerHealth;

    private void Start()
    {
        _playerHealth = FindObjectOfType<PlayerHealth>();
    }

    public void AttackHitEvent()
    {
        if (_playerHealth == null)
        {
            Debug.LogError("PlayerHealth is NULL!");
            return;
        }

        _playerHealth.TakeDamage(_damage);
    }
}
