using UnityEngine;

public class DeadState : AState
{
    public override void EnterState(EnemyStateManager enemyManager)
    {
        
        enemyManager.animator.SetBool("is_Dead", true);
        enemyManager.animator.SetBool("is_Attacking", false);
        enemyManager.animator.SetBool("is_Angry", false);
        Debug.Log("Dead Enetered");
        enemyManager.SetSpeed(0);

    }
    public override void ExitState(EnemyStateManager enemyManager)
    {
    }
    public override void UpdateState(EnemyStateManager enemyManager)
    {
    }
}
