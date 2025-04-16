using UnityEngine;

public class AttackState: AState
{
    public override void EnterState(EnemyStateManager enemyManager)
    {
        // начало анимации атаки
        Debug.Log("Attack Enetered");
        enemyManager.animator.SetBool("is_Attacking", true);
        enemyManager.SetSpeed(0);
    }
    public override void ExitState(EnemyStateManager enemyManager)
    {
        Debug.Log("Attack Exit");
        enemyManager.animator.SetBool("is_Attacking", false);
    }
    public override void UpdateState(EnemyStateManager enemyManager)
    {
        if (enemyManager.CheckOnTarget() > enemyManager.attackDistance)
        {
            enemyManager.SwitchState(enemyManager.walkState);
        }
        enemyManager.RotateTowards(enemyManager.CheckOnTargetRotation());
        Debug.Log("Аттака!");
    }
}
