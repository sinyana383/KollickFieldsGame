using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Sources")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;

    [Header("Audio Clips")]
    [SerializeField] public AudioClip startLocationBackground;
    [SerializeField] public AudioClip buttonPress;

    private void Start()
    {
        musicSource.clip = startLocationBackground;
        musicSource.Play();
    }

    public void PlayButtonPress(AudioClip audioClip) 
    {
        sfxSource.PlayOneShot(audioClip);
    }
}
