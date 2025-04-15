using UnityEngine;

public class WalkState : AState
{
    public override void EnterState(EnemyStateManager enemyManager)
    {
        // начало анимации ходьбы
        Debug.Log("Walk Enetered");
        enemyManager.SetSpeed(enemyManager.walkSpeed);
    }
    public override void ExitState(EnemyStateManager enemyManager)
    {
        Debug.Log("Walk Exit");
    }
    public override void UpdateState(EnemyStateManager enemyManager)
    {
        if (enemyManager.CheckOnTarget() >= enemyManager.agroDistance)
        {
            enemyManager.SwitchState(enemyManager.idleState);
        }
        Debug.Log($"Distance {enemyManager.CheckOnTarget()} {enemyManager.attackDistance}");
        if (enemyManager.CheckOnTarget() <= enemyManager.attackDistance)
        {
            enemyManager.SwitchState(enemyManager.attackState);
        }
    }
}
