using UnityEngine;

public class IdleState : AState
{
    public override void EnterState(EnemyStateManager enemyStateManager)
    {
        enemyStateManager.SetAutoBreaking(true);
        enemyStateManager.animator.SetBool("is_Attacking", false);
        enemyStateManager.animator.SetBool("is_Angry", false);
    }

    public override void ExitState(EnemyStateManager enemyStateManager)
    {
    }

    public override void UpdateState(EnemyStateManager enemyStateManager)
    {
        if (enemyStateManager.GetRemainingDistance() < 0.5f)
                 enemyStateManager.GotoNextPoint();
        if (enemyStateManager.CheckOnTarget() < enemyStateManager.agroDistance) 
        {
            enemyStateManager.SwitchState(enemyStateManager.walkState);
        }
    }
}
