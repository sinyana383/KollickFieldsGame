using UnityEngine;

public class Breakable : Interactable
{
    [SerializeField] GameObject hitEffectPrefab;
    int toughness = 150;

    private void OnTriggerEnter(Collider other)
    {
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
        Destroy(gameObject);
    }

}
