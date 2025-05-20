using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;

public class PlayerBounderies : MonoBehaviour
{
    DynamicMoveProvider moveProvider;

    private void Awake()
    {
        moveProvider = GetComponent<DynamicMoveProvider>();
    }

    private void OnEnable()
    {
        EventManager.Zone.OnFieldExit += StopPlayer;
        EventManager.Zone.OnPlayerRelease += ReleasePlayer;
    }

    private void OnDisable()
    {
        EventManager.Zone.OnFieldExit -= StopPlayer;
        EventManager.Zone.OnPlayerRelease -= ReleasePlayer;
    }

    private void StopPlayer()
    {
        moveProvider.moveSpeed = 0;
    }

    private void ReleasePlayer()
    {
        moveProvider.moveSpeed = 5; //TODO: Make this class like player speed of something
    }
}
