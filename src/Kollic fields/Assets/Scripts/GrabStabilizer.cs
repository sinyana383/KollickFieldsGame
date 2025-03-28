using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GrabStabilizer : MonoBehaviour
{
    public void OnGrab(SelectEnterEventArgs args) 
    {
        args.interactableObject.transform.SetParent(args.interactorObject.transform);
    }

    public void OnRelease(SelectExitEventArgs args)
    {
    }
}
