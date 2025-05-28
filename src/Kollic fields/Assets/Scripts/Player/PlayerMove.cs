using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;

public class PlayerMove : MonoBehaviour
{
    DynamicMoveProvider moveProvider;
    
    [Header("Speed Settings")]
    [SerializeField] private float normalSpeed = 5f;
    [SerializeField] private float acceleration = 1.5f;

    private void Awake()
    {
        moveProvider = GetComponent<DynamicMoveProvider>();
    }

    private void OnEnable()
    {
        EventManager.Zone.OnWarningEntered += arg0 => SlowDonwn();
        EventManager.Zone.OnPlayerRelease += NormalSpeed;
    }

    private void OnDisable()
    {
        EventManager.Zone.OnWarningEntered -= arg0 => SlowDonwn();
        EventManager.Zone.OnPlayerRelease -= NormalSpeed;
    }

    private void SlowDonwn()
    {
        moveProvider.moveSpeed /= acceleration;
    }

    public void NormalSpeed()
    {
        moveProvider.moveSpeed = normalSpeed;
    }

    public void Accelerate()
    {
        moveProvider.moveSpeed *= acceleration;
    }
}
