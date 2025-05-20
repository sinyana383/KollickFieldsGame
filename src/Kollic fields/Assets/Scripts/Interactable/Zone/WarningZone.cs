using System;
using TMPro;
using UnityEngine;

public class WarningZone : Zone
{
    [SerializeField] private string warningText;
    
    protected override void FunctionOnTriggerEnter(Collider other)
    {
        if (!enteredZone)
        {
            Debug.Log("WarningZone FunctionOnTriggerEnter");
            EventManager.Zone.OnWarningEntered?.Invoke(warningText);
        }
        base.FunctionOnTriggerEnter(other);
    }

    private void OnTriggerExit(Collider other)
    {
        enteredZone = false;
    }
}
