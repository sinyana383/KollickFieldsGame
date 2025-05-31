using System;
using UnityEngine;

public class AudioSourceSetting : MonoBehaviour
{
    enum AudioType
    {
        sound,
        music,
        voice
    }
    [SerializeField] private AudioType audioType = AudioType.sound;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private bool playOnStart;
    
    [Header("Audio Clips")]
    [SerializeField] private AudioClip[] audioClips;
    private void OnEnable()
    {
        if (audioType == AudioType.sound)
            EventManager.Game.OnSoundVolumeChanged += ChangeVolume;
        if (audioType == AudioType.music)
        {
            EventManager.Game.OnMusicVolumeChanged += ChangeVolume;
            EventManager.Akratit.OnAkratitSpotPlayer += AudioPlay;
            EventManager.Akratit.OnAkratitLosePlayer += AudioPlay;
        }
        if (audioType == AudioType.voice)
            EventManager.Game.OnVoiceChanged += ChangeVolume;
    }

    private void OnDisable()
    {
        if (audioType == AudioType.sound)
            EventManager.Game.OnSoundVolumeChanged -= ChangeVolume;
        if (audioType == AudioType.music)
        {
            EventManager.Game.OnMusicVolumeChanged -= ChangeVolume;
            EventManager.Akratit.OnAkratitSpotPlayer -= AudioPlay;
            EventManager.Akratit.OnAkratitLosePlayer -= AudioPlay;
        }
        if (audioType == AudioType.voice)
            EventManager.Game.OnVoiceChanged -= ChangeVolume;
    }

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        if (playOnStart)
            AudioPlay(0);
    }

    public void ChangeVolume(float volume)
    {
        audioSource.volume = volume;
    }
    
    public void AudioPlayOneShot(int index) 
    {
        if (index >= audioClips.Length) return;
        audioSource.PlayOneShot(audioClips[index]);
    }

    public void AudioPlay(int index)
    {
        if (index >= audioClips.Length) return;
        if (audioSource == null)
            audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
            return;
        audioSource.clip = audioClips[index];
        audioSource.Play();
        if (audioType == AudioType.music)
            audioSource.loop = true;
    }
    
    public int GetAudioClipCount() => audioClips.Length;
}
