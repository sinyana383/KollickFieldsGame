using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class SliderManager : MonoBehaviour
{
    [SerializeField] private Volume volume;
    [SerializeField] private AudioSource BackgroundAudioSource;
    [SerializeField] private AudioSource soundAudioSource;
    private ColorAdjustments colorAdjustments;
    
    [SerializeField] Slider soundSlider;
    [SerializeField] Slider musicSlider;
    [SerializeField] Slider brightnessSlider;

    private void Start()
    {
        volume.profile.TryGet(out colorAdjustments);
        brightnessSlider.onValueChanged.AddListener(ChangeBrightness);
        musicSlider.onValueChanged.AddListener(ChangeMusic);
        soundSlider.onValueChanged.AddListener(ChangeSound);

        soundSlider.value = soundAudioSource.volume;
        musicSlider.value = BackgroundAudioSource.volume;
        brightnessSlider.value = colorAdjustments.postExposure.value;

    }

    void ChangeBrightness(float value)
    {
        colorAdjustments.postExposure.value = value;
    }

    void ChangeMusic(float value) 
    {
        BackgroundAudioSource.volume = value;
    }

    void ChangeSound(float value)
    {
        soundAudioSource.volume = value;
    }
}
