using UnityEngine;

public class WalkState : AState
{
    public override void EnterState(EnemyStateManager enemyManager)
    {
        // начало анимации ходьбы

        enemyManager.animator.SetBool("is_Angry", true);
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
            enemyManager.animator.SetBool("is_Angry", false);
            enemyManager.SwitchState(enemyManager.idleState);
        }
        Debug.Log($"Distance {enemyManager.CheckOnTarget()} {enemyManager.attackDistance}");
        if (enemyManager.CheckOnTarget() <= enemyManager.attackDistance)
        {
            enemyManager.animator.SetBool("is_Angry", true);
            enemyManager.SwitchState(enemyManager.attackState);
        }
    }
}
