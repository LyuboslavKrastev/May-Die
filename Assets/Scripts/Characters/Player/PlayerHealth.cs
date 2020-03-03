using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int _hitPoints = 500;
    [SerializeField] private TextMeshProUGUI _healthText;

    void Start()
    {
        UpdateHealthText();
    }

    private void UpdateHealthText()
    {
        _healthText.text = $"Health: {_hitPoints}";
    }

    public void TakeDamage(int damage)
    {       
        if (_hitPoints > 0)
        {
            _hitPoints -= damage;
            UpdateHealthText();
        }
        else
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
}
