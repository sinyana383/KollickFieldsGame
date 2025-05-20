using UnityEngine;

public class EnsurePanel : ClosablePanel
{
    protected override void ClosePanel()
    {
        EventManager.Zone.OnPlayerRelease?.Invoke();
        base.ClosePanel();
    }
}
