using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Body : Interactable
{
    public override void ActionOnDetection(SelectEnterEventArgs args)
    {
        base.ActionOnDetection(args);
        EventManager.Bodies.OnBodiesFound?.Invoke(TaskManager.TasksNames.FindPeople);
    }
}
