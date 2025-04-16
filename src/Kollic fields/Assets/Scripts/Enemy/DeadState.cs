using UnityEngine;

public class DeadState : AState
{
    public override void EnterState(EnemyStateManager enemyManager)
    {
        // начало анимации idle
        Debug.Log("Dead Enetered");
        enemyManager.SetSpeed(0);

    }
    public override void ExitState(EnemyStateManager enemyManager)
    {
        Debug.Log("Dead Exit????");
    }
    public override void UpdateState(EnemyStateManager enemyManager)
    {
        // провалить его сквозь пол
    }
}
