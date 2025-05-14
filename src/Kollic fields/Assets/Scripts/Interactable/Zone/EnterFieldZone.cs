using UnityEngine;

public class EnterFieldZone : Zone
{
    private void OnTriggerEnter(Collider other)
    {
        if (!enteredZone)
            EventManager.Zone.OnFieldEntered?.Invoke();
    }
}
