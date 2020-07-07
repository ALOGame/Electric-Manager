using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;

using UnityEngine;

public static class LevelLoader
{
    public static Level LoadLevel(string path)
    {
        XmlDocument document = new XmlDocument();
        document.Load(path);

        XmlElement levelEl = document.DocumentElement;

        string levelName = levelEl.GetAttribute("name");
        List<ApplianceInfo> staticAppliancesInfos = new List<ApplianceInfo>();
        List<ApplianceInfo> movableAppliancesInfos = new List<ApplianceInfo>();
        List<Wire> wires = new List<Wire>();

        XmlElement appliances = levelEl["appliances"];

        XmlElement appliancesStaticEl = appliances["static"];
        foreach (XmlElement applianceEl in appliancesStaticEl.ChildNodes)
        {
            ApplianceType applianceType;
            if (!Enum.TryParse(applianceEl.Name, out applianceType))
                throw new ArgumentException("Invalid AppliactionType enum name");

            string[] gridPositionStr = applianceEl.GetAttribute("gridPosition").Split(',');
            Vector2 gridPosition = new Vector2(int.Parse(gridPositionStr[0]), int.Parse(gridPositionStr[1]));

            List<Modifier> modifiers = new List<Modifier>();
            if (applianceEl.ChildNodes.Count == 1)
            {
                if (applianceEl.ChildNodes[0].Name.Equals("modifiers"))
                {
                    XmlNode modifiersEl = applianceEl.ChildNodes[0];
                    foreach (XmlElement modifierEl in modifiersEl.ChildNodes)
                    {
                        Modifier modifier = Modifier.GetByName(modifierEl.Name);
                        if (modifier == null)
                            throw new ArgumentException("Modifier not found: " + modifierEl.Name);

                        modifiers.Add(modifier);
                    }
                } else
                {
                    throw new ArgumentException("Expecting to find \"modifiers\" element. Found instead: " + applianceEl.ChildNodes[0].Name);
                }
            }

            ApplianceData applianceData = new ApplianceData();
            XmlElement applianceDataEl = applianceEl["data"];
            foreach (XmlElement data in applianceDataEl.ChildNodes)
            {
                applianceData.AddData(data.Name, data.InnerText);
            }

            staticAppliancesInfos.Add(new ApplianceInfo(applianceType, gridPosition, modifiers, applianceData));
        }

        XmlElement appliancesMovableEl = appliances["movable"];
        foreach (XmlElement applianceEl in appliancesMovableEl.ChildNodes)
        {
            ApplianceType applianceType;
            if (!Enum.TryParse(applianceEl.Name, out applianceType))
            {
                throw new ArgumentException("Invalid AppliactionType enum name");
            }

            string[] gridPositionStr = applianceEl.GetAttribute("gridPosition").Split(',');
            Vector2 gridPosition = new Vector2(int.Parse(gridPositionStr[0]), int.Parse(gridPositionStr[1]));

            List<Modifier> modifiers = new List<Modifier>();
            if (applianceEl.ChildNodes.Count == 1)
            {
                if (applianceEl.ChildNodes[0].Name.Equals("modifiers"))
                {
                    XmlNode modifiersEl = applianceEl.ChildNodes[0];
                    foreach (XmlElement modifierEl in modifiersEl.ChildNodes)
                    {
                        Modifier modifier = Modifier.GetByName(modifierEl.Name);
                        if (modifier == null)
                            throw new ArgumentException("Modifier not found: " + modifierEl.Name);

                        modifiers.Add(modifier);
                    }
                }
                else
                {
                    throw new ArgumentException("Expecting to find \"modifiers\" element. Found instead: " + applianceEl.ChildNodes[0].Name);
                }
            }

            ApplianceData applianceData = new ApplianceData();
            XmlElement applianceDataEl = applianceEl["data"];
            foreach (XmlElement data in applianceDataEl.ChildNodes)
            {
                applianceData.AddData(data.Name, data.InnerText);
            }

            movableAppliancesInfos.Add(new ApplianceInfo(applianceType, gridPosition, modifiers, applianceData));
        }

        XmlElement wiresEl = levelEl["wires"];
        foreach (XmlElement wireEl in wiresEl.ChildNodes)
        {
            string[] gridPositionStr = wireEl.GetAttribute("gridPosition").Split(',');
            Vector2 gridPosition = new Vector2(int.Parse(gridPositionStr[0]), int.Parse(gridPositionStr[1]));

            WireDirection wireDirection = (WireDirection)int.Parse(wireEl.GetAttribute("direction"));

            wires.Add(new Wire(gridPosition, wireDirection));
        }

        return new Level(levelName, staticAppliancesInfos, movableAppliancesInfos, wires);
    }
}
