using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnityEngine;

public class Wire
{
    public Vector2 GridPosition { get; protected set; }
    public WireDirection WireDirection { get; protected set; }

    public Wire (Vector2 gridPosition, WireDirection wireDirection)
    {
        GridPosition = gridPosition;
        WireDirection = wireDirection;
    }
}
