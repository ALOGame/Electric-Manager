using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnityEngine;

public class GameObjectManager : MonoBehaviour
{
    private static GameObjectManager instance;

    public GameObject powerSwitch;
    public GameObject target;

    private static GameObject GetPowerSwitch() => instance.powerSwitch;
    private static GameObject GetTarget() => instance.target;

    private GameObjectManager() { }
    private void Awake()
    {
        instance = this;
    }

    public static GameObject GetAppliance(ApplianceType type)
    {
        switch (type)
        {
            case ApplianceType.PowerSwitch:
                return GetPowerSwitch();
            case ApplianceType.Target:
                return GetTarget();
            default:
                Debug.LogError("Appliance type not found: " + type);
                return null;
        }
    }
}
