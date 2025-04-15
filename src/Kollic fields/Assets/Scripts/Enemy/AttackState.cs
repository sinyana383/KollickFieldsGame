using UnityEngine;

public class AttackState: AState
{
    public override void EnterState(EnemyStateManager enemyManager)
    {
        // начало анимации ходьбы
        Debug.Log("Attack Enetered");
        enemyManager.SetSpeed(enemyManager.walkSpeed);
    }
    public override void ExitState(EnemyStateManager enemyManager)
    {

    }
    public override void UpdateState(EnemyStateManager enemyManager)
    {
        if (enemyManager.CheckOnTarget() >= enemyManager.agroDistance)
        {
            enemyManager.SwitchState(enemyManager.idleState);
        }
    }
}
