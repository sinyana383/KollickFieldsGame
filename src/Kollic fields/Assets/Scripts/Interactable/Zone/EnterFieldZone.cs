using UnityEngine;

public class EnterFieldZone : Zone
{
    private void OnTriggerEnter(Collider other)
    {
        FunctionOnTriggerEnter(other);
    }

    protected override void FunctionOnTriggerEnter(Collider other)
    {
        if (!enteredZone)
        {
            Debug.Log("EnterFieldZone FunctionOnTriggerEnter");
            EventManager.Zone.OnFieldEntered?.Invoke();
        }
        base.FunctionOnTriggerEnter(other);
    }
}
