using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class PokeResponder : MonoBehaviour
{
    public XRSimpleInteractable interactable;

    void Awake()
    {
        interactable.activated.AddListener(OnPoked);
    }

    private void OnPoked(ActivateEventArgs args)
    {
        Debug.Log("GameObject poked with trigger!");
    }
}