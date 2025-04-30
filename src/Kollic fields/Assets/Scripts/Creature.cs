using System.Text.RegularExpressions;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;

public class Creature : MonoBehaviour
{
    int hp = 100;
    public bool isDead;
    [SerializeField] EnemyStateManager enemyStateManager;

    private void Awake()
    {
        isDead = false;
        enemyStateManager = GetComponent<EnemyStateManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Weapon weapon))
        {
            this.hp -= weapon.Dmg;
            Debug.Log($"HP: {hp}");
            Dead();
        }

        void Dead()
        {
            if (this.hp <= 0 && !isDead)
            {
                isDead = true;
                enemyStateManager.SwitchState(enemyStateManager.deadState);
                //Destroy(this.gameObject);
            }
        }
    }

}
