using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int _hitPoints = 100;

    public void TakeDamage(int damage)
    {
        if (_hitPoints > 0)
        {
            _hitPoints -= damage;
        }
        else
        {
            Debug.Log("Player is dead");
        }
    }
}
