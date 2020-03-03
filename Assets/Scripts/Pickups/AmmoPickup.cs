using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    [SerializeField] private int _amount = 50;

    [SerializeField] private AmmoType _type;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerPickupHandler pickupHandler = other.GetComponent<PlayerPickupHandler>();
            NullAlerter.AlertIfNull(pickupHandler, nameof(pickupHandler));
            pickupHandler.TakeAmmo(_type, _amount);
            Destroy(gameObject);
        }
    }
}
