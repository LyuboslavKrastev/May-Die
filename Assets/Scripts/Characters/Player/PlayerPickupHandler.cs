using UnityEngine;

public class PlayerPickupHandler : MonoBehaviour
{
    public void TakeAmmo(AmmoType type, int ammount)
    {
        Transform weaponTransform = GetWeaponTransform(type);
        NullAlerter.AlertIfNull(weaponTransform, "The selected weapon for taking ammo");

        Ammo weaponAmmo = weaponTransform.GetComponent<Ammo>();
        NullAlerter.AlertIfNull(weaponAmmo, nameof(weaponAmmo));

        weaponAmmo.IncreaseAmmo(ammount);
    }

    private Transform GetWeaponTransform(AmmoType type)
    {
        WeaponSwitcher weapons = GetComponentInChildren<WeaponSwitcher>();
        NullAlerter.AlertIfNull(weapons, nameof(weapons));

        print(weapons.BLUEROSE_INDEX);
        print(weapons.REDQUEEN_INDEX);
        int weaponIndex = 0;

        switch (type)
        {
            case AmmoType.GunBullets:
                weaponIndex = weapons.BLUEROSE_INDEX;
                break;
            case AmmoType.Shells:
                weaponIndex = weapons.REDQUEEN_INDEX;
                break;
            case AmmoType.PistolBullets:
                weaponIndex = weapons.EBONYANDIVORY_INDEX;
                break;
        }

        return weapons.transform.GetChild(weaponIndex); ;
    }
}
