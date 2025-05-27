using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    [SerializeField] private string savefileName = "settingsManager";
    [SerializeField] private Button saveButton;
    
    [SerializeField] private Volume volume;
    [SerializeField] private ColorAdjustments colorAdjustments;
    
    [SerializeField] Slider soundSlider;
    [SerializeField] Slider musicSlider;
    [SerializeField] Slider brightnessSlider;
    [SerializeField] Slider voiceSlider;
    
    [SerializeField] float backgroundVolume;
    [SerializeField] float soundVolume;
    [SerializeField] float brightness;
    [SerializeField] float voice;
    
    public float BackgroundVolume 
    { 
        get => backgroundVolume;
        set
        {
            backgroundVolume = value;
            if (musicSlider != null)
            {
                musicSlider.value = backgroundVolume;
                EventManager.Game.OnMusicVolumeChanged?.Invoke(backgroundVolume);
            }
        }
    }
    public float SoundVolume 
    { 
        get => soundVolume;
        set
        {
            soundVolume = value;
            if (soundSlider != null)
            {
                soundSlider.value = soundVolume;
                EventManager.Game.OnSoundVolumeChanged?.Invoke(soundVolume);
            }
        }
    }
    public float Voice
    {
        get => voice;
        set
        {
            voice = value;
            if (voiceSlider != null) 
            {
                voiceSlider.value = voice;
                EventManager.Game.OnVoiceChanged?.Invoke(voice);
            }
        }
    }
    public float Brightness
    {
        get => brightness;
        set
        {
            brightness = value;
            if (colorAdjustments == null)
            {
                if (volume != null)
                    volume.profile.TryGet(out colorAdjustments);
            }

            if (colorAdjustments != null)
            {
                colorAdjustments.postExposure.value = brightness;
                brightnessSlider.value = colorAdjustments.postExposure.value;
            }
        }
    }


    private void OnEnable()
    {
        EventManager.Save.OnSaveSettings += SaveSettings;
    }

    private void OnDisable()
    {
        EventManager.Save.OnSaveSettings -= SaveSettings;
    }

    public void SaveSettings() => SaveManager.SaveData(new SaveData.SettingsData(this), savefileName);
    
    public void LoadSettings() 
    {
        SaveData.SettingsData settingsData = SaveManager.LoadData<SaveData.SettingsData>(savefileName);
        
        if (settingsData == null)
        {
            return;
        }
        
        BackgroundVolume = settingsData.backgroundVolume;
        SoundVolume = settingsData.soundVolume;
        Brightness = settingsData.brightness;
        Voice = settingsData.voiceValume;
    }
    
    private void Start()
    {
        if (volume != null)
            volume.profile.TryGet(out colorAdjustments);
        brightnessSlider.onValueChanged.AddListener(ChangeBrightness);
        voiceSlider.onValueChanged.AddListener(ChangeVoice);
        musicSlider.onValueChanged.AddListener(ChangeMusic);
        soundSlider.onValueChanged.AddListener(ChangeSound);
        saveButton.onClick.AddListener(() => EventManager.Save.OnSaveSettings?.Invoke());
        
        LoadSettings();
    }

    void ChangeBrightness(float value)
    {
        Brightness = value;
    }

    void ChangeMusic(float value) 
    {
        BackgroundVolume = value;
    }

    void ChangeSound(float value)
    {
        SoundVolume = value;
    }

    void ChangeVoice(float value)
    {
        Voice = value;
    }
}
