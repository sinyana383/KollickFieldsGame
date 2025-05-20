using UnityEngine;

public class EnterFieldZone : Zone
{
    private void OnTriggerEnter(Collider other)
    {
        if (!enteredZone)
        {
            enteredZone = true;
            EventManager.Zone.OnFieldEntered?.Invoke();
        }
        else if (enteredZone)
        {
            Debug.Log($"EnterFieldZone.OnTriggerEnter({other.name})");
            EventManager.Zone.OnFieldExit?.Invoke();
        }
    }
}
