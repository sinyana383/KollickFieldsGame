using UnityEngine;

public class IdleState : AState
{
    public override void EnterState(EnemyStateManager enemyManager) 
    {
        // начало анимации idle
        Debug.Log("Idle Enetered");
        enemyManager.SetSpeed(0);
    }
    public override void ExitState(EnemyStateManager enemyManager) { }
    public override void UpdateState(EnemyStateManager enemyManager) 
    {
        if (enemyManager.CheckOnTarget() < enemyManager.agroDistance) 
        {
            enemyManager.SwitchState(enemyManager.attackState);
        }
    }
}
