using UnityEngine;
using UnityEngine.AI;

public class PatrolState : AState
{
    

    public override void EnterState(EnemyStateManager enemyStateManager)
    {
        EventManager.Akratit.OnAkratitLosePlayer?.Invoke(0);
        enemyStateManager.SetAutoBreaking(true);
        enemyStateManager.animator.SetBool("is_Attacking", false);
        enemyStateManager.animator.SetBool("is_Angry", false);
    }

    public override void ExitState(EnemyStateManager enemyStateManager)
    {
        EventManager.Akratit.OnAkratitSpotPlayer?.Invoke(1);
    }

    public override void UpdateState(EnemyStateManager enemyStateManager)
    {
        if (enemyStateManager.GetRemainingDistance() < 0.5f)                        
                 enemyStateManager.GotoNextPoint();
        if (enemyStateManager.CheckOnTarget() < enemyStateManager.agroDistance) 
        {
            enemyStateManager.SwitchState(enemyStateManager.AgroState);
            
        }
    }
}
