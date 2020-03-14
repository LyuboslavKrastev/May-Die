using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    private const float MAX_HEALTH = 500f;
    [SerializeField] private float _currentHealth = MAX_HEALTH;
    [SerializeField] private Slider _healthBar;
    [SerializeField] private Text _healthText;

    void Start()
    {
        UpdateHealthBar(100);
    }

    private void UpdateHealthBar(float healthPercentage)
    {
        _healthText.text = _currentHealth.ToString();
        _healthBar.value = healthPercentage;
    }

    float CalculateHealth()
    {
        return _currentHealth / MAX_HEALTH;
    }

    public void TakeDamage(int damage)
    {       
        if (_currentHealth > 0)
        {
            _currentHealth -= damage;
            float healthPercentage = CalculateHealth();
            UpdateHealthBar(healthPercentage);
        }
        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        DeathHandler deathHandler = GetComponent<DeathHandler>();

        if (deathHandler == null)
        {
            Debug.LogError("DeathHandler is NULL!");
            return;
        }

        deathHandler.HandleDeath();
    }
}
