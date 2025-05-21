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
        if (volume != null)
            volume.profile.TryGet(out colorAdjustments);
        brightnessSlider.onValueChanged.AddListener(ChangeBrightness);
        musicSlider.onValueChanged.AddListener(ChangeMusic);
        soundSlider.onValueChanged.AddListener(ChangeSound);
        
        if (soundAudioSource != null)
            soundSlider.value = soundAudioSource.volume;
        if (BackgroundAudioSource != null)
            musicSlider.value = BackgroundAudioSource.volume;
        if (colorAdjustments != null)
            brightnessSlider.value = colorAdjustments.postExposure.value;

    }

    void ChangeBrightness(float value)
    {
        if (colorAdjustments != null)
            colorAdjustments.postExposure.value = value;
    }

    void ChangeMusic(float value) 
    {
        if (BackgroundAudioSource != null)
            BackgroundAudioSource.volume = value;
    }

    void ChangeSound(float value)
    {
        if (soundAudioSource != null)
            soundAudioSource.volume = value;
    }
}
