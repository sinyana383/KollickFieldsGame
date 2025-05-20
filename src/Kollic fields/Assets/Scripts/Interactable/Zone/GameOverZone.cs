using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverZone : Zone
{
    protected override void FunctionOnTriggerEnter(Collider other)
    {
        EventManager.GameOver.OnGameOver?.Invoke();
        SceneManager.LoadScene(0);
    }
}
