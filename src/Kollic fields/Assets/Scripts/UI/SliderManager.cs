using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class SliderManager : MonoBehaviour
{
    [SerializeField] private Volume volume;
    private ColorAdjustments colorAdjustments;
    
    [SerializeField] Slider soundSlider;
    [SerializeField] Slider musicSlider;
    [SerializeField] Slider brightnessSlider;

    private void Start()
    {
        volume.profile.TryGet(out colorAdjustments);
        brightnessSlider.onValueChanged.AddListener(ChangeBrightness);
    }

    void ChangeBrightness(float value)
    {
        colorAdjustments.postExposure.value = value;
    }
}
