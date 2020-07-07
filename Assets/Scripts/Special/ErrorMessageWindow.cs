using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnityEngine;

public class ErrorMessageWindow : MonoBehaviour
{
    private static ErrorMessageWindow instance;

    private void Awake()
    {
        instance = this;
    }

    private void Popup(string text)
    {
        Debug.LogWarning("ErrorMessageWindow.Popup not implemented\n" + text);
    }

    public static void Show(string text)
    {
        instance.Popup(text);
    }
}
