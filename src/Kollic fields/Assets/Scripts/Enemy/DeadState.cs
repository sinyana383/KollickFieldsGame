using UnityEngine;

public class DeadState : AState
{
    public override void EnterState(EnemyStateManager enemyManager)
    {
        enemyManager.DisableAgent();
        enemyManager.animator.SetBool("is_Dead", true);
        enemyManager.animator.SetBool("is_Attacking", false);
        enemyManager.animator.SetBool("is_Angry", false);
        Debug.Log("Dead Enetered");

        EventManager.Akratit.OnAkratitDeath?.Invoke();  // TODO: поставить Event в анимации, когда Акратит упадет
    }
    public override void ExitState(EnemyStateManager enemyManager)
    {
    }
    public override void UpdateState(EnemyStateManager enemyManager)
    {
    }
}
