using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class WarningPanel : ClosablePanel
{
    protected override void ClosePanel()
    {
        EventManager.Zone.OnPlayerRelease?.Invoke();
        base.ClosePanel();
    }
}
