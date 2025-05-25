using System;
using UnityEngine;


public enum SoundType
{
    Button,
    Typing,
    Voice
}

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    
    [SerializeField] private AudioClip[] sounds;
    private static SoundManager instance;
    private AudioSource audioSource;

    private void Awake()
    {
        instance = this;
        audioSource = GetComponent<AudioSource>();
    }

    public static void PlaySound(SoundType soundType, float volume = 1f)
    {
        instance.audioSource.PlayOneShot(instance.sounds[(int)soundType], volume);
    }
}
