using UnityEngine;
using UnityEngine.Audio;

public class EnemyZone : Zone
{
    protected override void FunctionOnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
            base.FunctionOnTriggerEnter(other);
    }
}