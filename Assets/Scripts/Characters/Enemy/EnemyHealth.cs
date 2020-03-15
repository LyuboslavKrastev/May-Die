using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    private const float MAX_HEALTH = 600f;

    [SerializeField] private float _currentHealth = MAX_HEALTH;
    private Slider _healthBar;

    public bool IsDead { get; private set; }

    void Start()
    {
        _healthBar = GetComponentInChildren<Slider>();
        NullAlerter.AlertIfNull(_healthBar, nameof(_healthBar));
        UpdateHealthBar(100);
    }

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;
        UpdateUI();

        if (_currentHealth < 1 && IsDead == false)
        {
            Die();
        }
        BroadcastMessage("OnDamageTaken"); // at the moement such a method only exists within the EnemyAI class
    }

    private void UpdateUI()
    {
        float healthPercentage = CalculateHealth();
        UpdateHealthBar(healthPercentage);
    }

    private float CalculateHealth()
    {
        return _currentHealth / MAX_HEALTH;
    }

    private void UpdateHealthBar(float healthPercentage)
    {
        _healthBar.value = healthPercentage;
    }

    private void Die()
    {
        IsDead = true;
        _healthBar.transform.parent.gameObject.SetActive(false);
        GetComponent<Animator>().SetTrigger("die");
        Destroy(gameObject, 8f);
    }
}
