using UnityEngine;

public class AttackState: AState
{
    public override void EnterState(EnemyStateManager enemyManager)
    {
        // начало анимации атаки
        Debug.Log("Attack Enetered");
        enemyManager.SetSpeed(0);
        enemyManager.animator.SetBool("is_Attacking", true);
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
            //enemyManager.animator.SetBool("is_Attacking", false);
        }
        Debug.Log("Аттака!");
    }
}
