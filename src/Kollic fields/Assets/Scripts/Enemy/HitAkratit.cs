using UnityEngine;
using UnityEngine.Events;

public class HitAkratit : MonoBehaviour
{
    public GameObject hitEffectPrefab;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Weapon weapon))
        {
            if (hitEffectPrefab != null)
                Instantiate(hitEffectPrefab, other.ClosestPoint(transform.position), Quaternion.identity);
            EventManager.Akratit.OnAkratitHit?.Invoke(weapon.dmg);
        }
    }
}
