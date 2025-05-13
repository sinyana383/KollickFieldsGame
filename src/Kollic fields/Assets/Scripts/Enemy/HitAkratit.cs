using UnityEngine;
using UnityEngine.Events;

public class HitAkratit : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Weapon weapon))
        {
            EventManager.Akratit.OnAkratitHit?.Invoke(weapon.dmg);
        }
    }
}
