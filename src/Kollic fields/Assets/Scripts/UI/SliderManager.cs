using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class SliderManager : MonoBehaviour
{
    [SerializeField] private Volume volume;
    [SerializeField] private AudioSource BackgroundAudioSource;
    private ColorAdjustments colorAdjustments;
    
    [SerializeField] Slider soundSlider;
    [SerializeField] Slider musicSlider;
    [SerializeField] Slider brightnessSlider;

    private void Start()
    {
        volume.profile.TryGet(out colorAdjustments);
        brightnessSlider.onValueChanged.AddListener(ChangeBrightness);
        musicSlider.onValueChanged.AddListener(ChangeMusic);
    }

    void ChangeBrightness(float value)
    {
        colorAdjustments.postExposure.value = value;
    }

    void ChangeMusic(float value) 
    {
        BackgroundAudioSource.volume = value;
    }
}
