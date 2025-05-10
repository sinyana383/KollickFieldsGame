using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class Idol : Breakable
{
    public override void ActionOnDetection(SelectEnterEventArgs args)
    {
        base.ActionOnDetection(args);
        EventManager.Idol.OnIdolFound?.Invoke();
    }
}
