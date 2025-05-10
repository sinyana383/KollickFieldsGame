using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

// public class Interactable : MonoBehaviour
// {
//     public XRSimpleInteractable interactable;
//
//     void Awake()
//     {
//         interactable = GetComponent<XRSimpleInteractable>();
//         interactable.selectEntered.AddListener(ActionOnDetection);
//     }
//
//     private void ActionOnDetection(SelectEnterEventArgs args)
//     {
//         Debug.Log($"{this.gameObject.name} found!");
//     }
// }