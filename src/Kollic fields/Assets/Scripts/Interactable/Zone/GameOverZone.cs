using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverZone : Zone
{
    protected override void FunctionOnTriggerEnter(Collider other)
    {
        EventManager.Game.OnGameOver?.Invoke();
        EventManager.Game.OnSceneTransition?.Invoke(0);
    }
}
