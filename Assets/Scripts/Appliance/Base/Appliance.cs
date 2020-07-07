using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public abstract class Appliance : MonoBehaviour
{
    private ApplianceInfo applianceInfo;
    public ApplianceInfo ApplianceInfo
    {
        get => applianceInfo;
        set
        {
            applianceInfo = value;
            PrepareSelf();
        }
    }

    protected void PrepareSelf()
    {
        foreach (Modifier modifier in applianceInfo.Modifiers)
        {
            modifier.ModifyAppliance(this);
        }
    }
}
