using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class Akratit : MonoBehaviour
{
    int hp = 100;
    public bool isDead;
    [SerializeField] EnemyStateManager enemyStateManager;

    private void OnEnable()
    {
        EventManager.Akratit.OnAkratitHit += GetDamage;
    }
    private void OnDisable()
    {
        EventManager.Akratit.OnAkratitHit -= GetDamage;
    }

    private void Awake()
    {
        isDead = false;
        enemyStateManager = GetComponent<EnemyStateManager>();
    }

    private void GetDamage(int damage) 
    {
        this.hp -= damage;
        Debug.Log($"HP: {hp}");
        if (this.hp <= 0 && !isDead) 
            Dead();
    }

    void Dead()
    {
        isDead = true;
        enemyStateManager.SwitchState(enemyStateManager.deadState);
        //Destroy(this.gameObject);
    }
}
