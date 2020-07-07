using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayGrid : MonoBehaviour
{
    private const int gridWidth = 8;
    private const int gridHeight = 8;

    public GameObject slotGO;

    public Vector2 offset;
    public Vector2 spacing;

    private Slot[,] slots;

    public void InitGrid()
    {
        slots = new Slot[gridWidth, gridHeight];
        
        for (int y = 0; y < gridHeight; y++)
        {
            for (int x = 0; x < gridWidth; x++)
            {
                slots[x, y] = Instantiate(slotGO, new Vector3(offset.x + x * spacing.x, offset.y + x * spacing.y), Quaternion.identity, transform).GetComponent<Slot>();
            }
        }
    }

    public void AddAppliances(List<ApplianceInfo> appliances)
    {
        foreach (ApplianceInfo applianceInfo in appliances)
        {
            Vector3 appliancePosition = new Vector3(offset.x + applianceInfo.GridPosition.x * spacing.x, offset.y + applianceInfo.GridPosition.y * spacing.y);
            Appliance appliance = Instantiate(GameObjectManager.GetAppliance(applianceInfo.ApplianceType), appliancePosition, Quaternion.identity, transform).GetComponent<Appliance>();
            appliance.ApplianceInfo = applianceInfo;
        }
    }
}
