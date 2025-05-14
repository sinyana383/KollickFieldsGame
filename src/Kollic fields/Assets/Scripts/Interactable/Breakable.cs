using UnityEngine;

public class Breakable : MonoBehaviour
{
    [SerializeField] GameObject hitEffectPrefab;
    int toughness = 150;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Breakable OnCollisionEnter");
        if (collision.gameObject.TryGetComponent(out Weapon weapon))
        {

            this.toughness -= weapon.Dmg;
            if (hitEffectPrefab != null)
                Instantiate(hitEffectPrefab, collision.contacts[0].point, Quaternion.identity);
            if (this.toughness <= 0)
                Broken();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Breakable OnTriggerEnter");
        if (other.gameObject.TryGetComponent(out Weapon weapon))
        {
            
            this.toughness -= weapon.Dmg;
            if (hitEffectPrefab != null)
                Instantiate(hitEffectPrefab, other.ClosestPoint(transform.position), Quaternion.identity);
            if (this.toughness <= 0)
                Broken();
        }
    }
    protected virtual void Broken()
    {
        EventManager.Idol.OnIdolDestroyed?.Invoke();
        Destroy(gameObject);
    }

}
