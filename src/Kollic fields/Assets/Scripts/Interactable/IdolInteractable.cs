using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class IdolInteractable : Interactable
{
    public override void ActionOnDetection(SelectEnterEventArgs args)
    {
        base.ActionOnDetection(args);
        EventManager.Idol.OnIdolFound?.Invoke(TaskManager.TasksNames.FindIdol);
    }
}
