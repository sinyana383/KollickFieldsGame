using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class Interactable : MonoBehaviour
{
    public XRSimpleInteractable interactable;
    void Awake()
    {
        interactable = GetComponent<XRSimpleInteractable>();
        if (interactable != null)
        {
            interactable.selectEntered.AddListener(ActionOnDetection);
            interactable.allowGazeInteraction = true;
            interactable.allowGazeSelect = true;
        }
    }

    public virtual void ActionOnDetection(SelectEnterEventArgs args)
    {
        Debug.Log($"{this.gameObject.name} found!");
    }
}
