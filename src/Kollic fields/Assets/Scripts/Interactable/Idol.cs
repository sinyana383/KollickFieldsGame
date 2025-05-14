using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class Idol : Interactable
{
    public override void ActionOnDetection(SelectEnterEventArgs args)
    {
        base.ActionOnDetection(args);
        EventManager.Idol.OnIdolFound?.Invoke();
    }

    //protected override void Broken() 
    //{
    //    EventManager.Idol.OnIdolDestroyed?.Invoke();
    //    base.Broken();
    //}
}
