using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NullAlerter : MonoBehaviour
{
    // Start is called before the first frame update
    public static void AlertIfNull(Component component, string name)
    {
        if (component == null)
        {
            Debug.LogError($"{name} is NULL!");
        }
    }
}
