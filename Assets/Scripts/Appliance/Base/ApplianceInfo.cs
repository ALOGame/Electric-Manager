using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnityEngine;

public class ApplianceInfo
{
    public ApplianceType ApplianceType { get; protected set; }
    public Vector2 GridPosition { get; protected set; }
    public List<Modifier> Modifiers { get; protected set; }
    public ApplianceData Data { get; protected set; }

    public ApplianceInfo(ApplianceType type, Vector2 gridPosition, List<Modifier> modifiers, ApplianceData data)
    {
        ApplianceType = type;
        GridPosition = gridPosition;
        Modifiers = modifiers;
        Data = data;
    }
}
