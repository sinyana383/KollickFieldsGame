using System;
using UnityEngine;
using UnityEngine.Events;
using Random = System.Random;

public class HitAkratit : MonoBehaviour
{
    AudioSourceSetting audioSettings;
    public GameObject hitEffectPrefab;

    private void Awake()
    {
        if (audioSettings == null)
            audioSettings = GetComponent<AudioSourceSetting>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Random rnd = new Random();
        if (other.gameObject.TryGetComponent(out Weapon weapon))
        {
            if (hitEffectPrefab != null)
                Instantiate(hitEffectPrefab, other.ClosestPoint(transform.position), Quaternion.identity);
            if (audioSettings != null)
            {
                audioSettings.AudioPlayOneShot(rnd.Next(0,audioSettings.GetAudioClipCount()));
            }
            EventManager.Akratit.OnAkratitHit?.Invoke(weapon.dmg);
        }
    }
}
