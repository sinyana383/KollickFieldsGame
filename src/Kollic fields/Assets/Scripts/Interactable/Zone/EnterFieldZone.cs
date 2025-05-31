using UnityEngine;

public class EnterFieldZone : Zone
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            FunctionOnTriggerEnter(other);
        }
    }

    protected override void FunctionOnTriggerEnter(Collider other)
    {
        if (!enteredZone)
        {
            Debug.Log("EnterFieldZone FunctionOnTriggerEnter");
            EventManager.Zone.OnFieldEntered?.Invoke(TaskManager.TasksNames.EnterField);
        }
        base.FunctionOnTriggerEnter(other);
    }
}
