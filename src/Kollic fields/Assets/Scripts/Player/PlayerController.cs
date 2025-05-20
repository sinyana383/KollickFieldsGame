using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;

public class PlayerController : MonoBehaviour
{
    @XRIDefaultInputActions inputActionManager;

    protected void Awake()
    {
        inputActionManager = new @XRIDefaultInputActions();
        
    }

    protected virtual void OnEnable()
    {
       inputActionManager.Enable();
    }


    protected virtual void OnDisable()
    {
        inputActionManager.Disable();
    }

    private void FixedUpdate()
    {
        inputActionManager.XRILeftInteraction.ButtonInteraction.performed += context => EventManager.Player.OnFlashlightSwitch?.Invoke();
    }

}
