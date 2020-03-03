using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int _hitPoints = 500;

    public void TakeDamage(int damage)
    {
        if (_hitPoints > 0)
        {
            _hitPoints -= damage;
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
