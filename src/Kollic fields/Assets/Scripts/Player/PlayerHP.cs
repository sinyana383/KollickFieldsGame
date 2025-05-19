using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    int hp = 100;

    void PlayerDead()
    {
        
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
