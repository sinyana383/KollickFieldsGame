using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class PokeResponder : MonoBehaviour
{
    public XRSimpleInteractable interactable;

    void Awake()
    {
        interactable = GetComponent<XRSimpleInteractable>();
        interactable.selectEntered.AddListener(OnPoked);
    }

    private void OnPoked(SelectEnterEventArgs args)
    {
        Debug.Log($"{this.gameObject.name} found!");
    }
}