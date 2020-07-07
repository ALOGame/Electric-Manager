using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level
{
    public string Name { get; private set; }
    public List<ApplianceInfo> StaticAppliancesInfos { get; private set; }
    public List<ApplianceInfo> MovableAppliancesInfos { get; private set; }
    public List<Wire> Wires { get; private set; }

    public Level(string name, List<ApplianceInfo> staticAppliances, List<ApplianceInfo> movableAppliances, List<Wire> wires)
    {
        Name = name;
        StaticAppliancesInfos = staticAppliances;
        MovableAppliancesInfos = movableAppliances;
        Wires = wires;
    }
}
