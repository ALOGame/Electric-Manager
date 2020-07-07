using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public PlayGrid playGrid;

    private Level level;

    private void Start()
    {
        try
        {
            level = LevelLoader.LoadLevel("test");
        } catch (IOException)
        {
            ErrorMessageWindow.Show("Could not open level");
            return;
        } catch (Exception)
        {
            ErrorMessageWindow.Show("Could not load level. Most likely an invalid format");
            return;
        }

        playGrid.InitGrid();
        playGrid.AddAppliances(level.StaticAppliancesInfos);
    }
}
