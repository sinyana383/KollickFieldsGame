using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class GrabStabilizer : MonoBehaviour
{
    [SerializeField] Transform rightAttachTransform;
    [SerializeField] Transform leftAttachTransform;
    public void OnGrab(SelectEnterEventArgs args) 
    {
        //args.interactableObject.transform.SetParent(args.interactorObject.transform);

        //if (args.interactorObject.transform.TryGetComponent(out LeftHand lefthand)) 
        //{
        //    Debug.Log("Left hand");
        //    if (this.TryGetComponent(out XRGrabInteractable xRGrabInteractable))
        //    {
        //        xRGrabInteractable.attachTransform = leftAttachTransform;
        //    }
        //}
        //if (args.interactorObject.transform.GetComponent<RightHand>())
        //{
        //    Debug.Log("Right Hand");
        //    if (this.TryGetComponent(out XRGrabInteractable xRGrabInteractable))
        //    {
        //        xRGrabInteractable.attachTransform = rightAttachTransform;
        //    }
        //}
    }

    public void OnRelease(SelectExitEventArgs args)
    {

    }
}
