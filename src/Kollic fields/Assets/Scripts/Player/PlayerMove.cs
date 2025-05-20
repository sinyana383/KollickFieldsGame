using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;

public class PlayerMove : MonoBehaviour
{
    DynamicMoveProvider moveProvider;

    private void Awake()
    {
        moveProvider = GetComponent<DynamicMoveProvider>();
    }

    private void OnEnable()
    {
        EventManager.Zone.OnWarningEntered += arg0 => StopPlayer();
        EventManager.Zone.OnPlayerRelease += ReleasePlayer;
    }

    private void OnDisable()
    {
        EventManager.Zone.OnWarningEntered -= arg0 => StopPlayer();
        EventManager.Zone.OnPlayerRelease -= ReleasePlayer;
    }

    private void StopPlayer()
    {
        moveProvider.moveSpeed = 0;
    }

    private void ReleasePlayer()
    {
        moveProvider.moveSpeed = 5;
    }
}
