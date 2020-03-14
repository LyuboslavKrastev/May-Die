using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private int _damage = 25;

    private PlayerHealth _playerHealth;
    private DisplayDamage _displayDamage;

    private void Start()
    {
        _playerHealth = FindObjectOfType<PlayerHealth>();
        if (_playerHealth == null)
        {
            NullAlerter.AlertIfNull(_playerHealth, "Player Health");
            return;
        }
        _displayDamage = _playerHealth.GetComponent<DisplayDamage>();
        if (_displayDamage == null)
        {
            NullAlerter.AlertIfNull(_displayDamage, "Display Damage");
            return;
        }

    }

    public void AttackHitEvent()
    {
       

        _playerHealth.TakeDamage(_damage);
        _displayDamage.ShowDamageCanvas();
    }
}
