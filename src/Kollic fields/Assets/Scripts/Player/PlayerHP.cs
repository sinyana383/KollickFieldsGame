using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHP : MonoBehaviour
{
    int hp = 100;

    void PlayerDead()
    {
        EventManager.GameOver.OnGameOver?.Invoke();
        SceneManager.LoadScene(0);
        Debug.Log("Player is dead");
    }
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log($"Trigger enter: {other.name}");
        if (other.gameObject.TryGetComponent(out EnemyDamager enemyDamager))
        {
            this.hp -= enemyDamager.enemyDmg;
            Debug.Log($"Player hp: {hp}");
            if (this.hp <= 0)
            {
                PlayerDead();
            }
        }
    }
}
