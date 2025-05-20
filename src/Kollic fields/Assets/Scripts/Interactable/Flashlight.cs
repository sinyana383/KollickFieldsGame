using UnityEngine;

public class Flashlight : MonoBehaviour
{
    [SerializeField] Light light;
    [SerializeField] bool isLightOn;

    private void Awake()
    {
        light = GetComponent<Light>();
    }

    private void OnEnable()
    {
        EventManager.Player.OnFlashlightSwitch += SwitchFlashlight;
    }
    private void OnDisable()
    {
        EventManager.Player.OnFlashlightSwitch -= SwitchFlashlight;
    }

    public void SwitchFlashlight() 
    {
        isLightOn = !isLightOn;
        light.enabled = isLightOn;
    }
}
