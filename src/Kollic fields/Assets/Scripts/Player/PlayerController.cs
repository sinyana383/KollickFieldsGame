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

    private void Start()
    {
        // change to thumbstick pressed
        // inputActionManager.XRILeftInteraction.ButtonInteraction.performed += context => EventManager.Player.OnStaminaUseEntered?.Invoke();
        // inputActionManager.XRILeftInteraction.ButtonInteraction.canceled += context => EventManager.Player.OnStaminaUseExited?.Invoke();

        inputActionManager.XRILeft.JoystickButton.performed += context => EventManager.Player.OnStaminaUseEntered?.Invoke();
        inputActionManager.XRILeft.JoystickButton.canceled += context => EventManager.Player.OnStaminaUseExited?.Invoke();


        inputActionManager.XRIRight.YButton.performed += context => EventManager.Player.OnFlashlightSwitch?.Invoke();
        inputActionManager.XRILeft.AButton.performed += context => EventManager.Player.OnMenuSwitch?.Invoke();
        inputActionManager.XRIRight.XButton.performed += context => EventManager.Player.OnTaskListSwitch?.Invoke();
    }

}
