using UnityEngine;

public class AttackState: AState
{
    public override void EnterState(EnemyStateManager enemyManager)
    {
        // начало анимации атаки
        Debug.Log("Attack Enetered");
        enemyManager.SetSpeed(0);
    }
    public override void ExitState(EnemyStateManager enemyManager)
    {
        Debug.Log("Attack Exit");
    }
    public override void UpdateState(EnemyStateManager enemyManager)
    {
        if (enemyManager.CheckOnTarget() > enemyManager.attackDistance)
        {
            enemyManager.SwitchState(enemyManager.walkState);
        }
        Debug.Log("Аттака!");
    }
}
