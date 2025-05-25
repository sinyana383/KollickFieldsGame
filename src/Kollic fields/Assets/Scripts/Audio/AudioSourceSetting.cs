using System;
using UnityEngine;

public class AudioSourceSetting : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    
    [Header("Audio Clips")]
    [SerializeField] private AudioClip[] audioClips;
    private void OnEnable()
    {
        EventManager.Game.OnSoundVolumeChanged += ChangeVolume;
    }

    private void OnDisable()
    {
        EventManager.Game.OnSoundVolumeChanged -= ChangeVolume;
    }

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void ChangeVolume(float volume)
    {
        audioSource.volume = volume;
    }
    
    public void PlayOneShot(int index) 
    {
        audioSource.PlayOneShot(audioClips[index]);
    }
}
