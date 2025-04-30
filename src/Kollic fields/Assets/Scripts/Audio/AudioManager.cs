using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Sources")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;

    [Header("Audio Clips")]
    [SerializeField] AudioClip startLocationBackground;

    private void Start()
    {
        musicSource.clip = startLocationBackground;
        musicSource.Play();
    }
}
