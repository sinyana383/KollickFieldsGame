using UnityEngine;

public class AgroState : AState
{
    public override void EnterState(EnemyStateManager enemyManager)
    {
        EventManager.Save.OnSaveAllDisable?.Invoke();
        EventManager.Akratit.OnAkratitFound?.Invoke();
        
        enemyManager.animator.SetBool("is_Angry", true);
        enemyManager.animator.SetBool("is_Attacking", false);
        
        //Debug.Log("Walk Enetered");
        enemyManager.SetSpeed(enemyManager.walkSpeed);


    }
    public override void ExitState(EnemyStateManager enemyManager)
    {
        //Debug.Log("Walk Exit");
        enemyManager.animator.SetBool("is_Angry", false);
        EventManager.Save.OnSaveAllEnable?.Invoke();
        //enemyManager.animator.SetBool("is_Attacking", false);
    }
    public override void UpdateState(EnemyStateManager enemyManager)
    {
        if (enemyManager.CheckOnTarget() > enemyManager.agroDistance)
        {
            EventManager.Akratit.RunFromAkratit?.Invoke(TaskManager.TasksNames.RunHome);
            //Debug.Log("enemyManager.CheckOnTarget() > enemyManager.agroDistance");
            enemyManager.animator.SetBool("is_Angry", false);
            enemyManager.animator.SetBool("is_Attacking", false);
            enemyManager.SwitchState(enemyManager.PatrolState);
        }

        if (enemyManager.CheckOnTarget() <= enemyManager.agroDistance && enemyManager.CheckOnTarget() <= enemyManager.attackDistance)
        {
            //Debug.Log("enemyManager.CheckOnTarget() <= enemyManager.agroDistance && enemyManager.CheckOnTarget() <= enemyManager.attackDistance");
            enemyManager.animator.SetBool("is_Angry", true);
            //enemyManager.animator.SetBool("is_Angry", false);
            enemyManager.animator.SetBool("is_Attacking", true);
            enemyManager.SwitchState(enemyManager.attackState);
        }


        //Debug.Log($"Distance {enemyManager.CheckOnTarget()} {enemyManager.attackDistance}");
        if (enemyManager.CheckOnTarget() <= enemyManager.agroDistance && enemyManager.CheckOnTarget() > enemyManager.attackDistance)
        {
            enemyManager.animator.SetBool("is_Angry", true);
            enemyManager.animator.SetBool("is_Attacking", false);
            enemyManager.SwitchState(enemyManager.AgroState);
        }

    }
    /*
    public override void UpdateState(EnemyStateManager enemyManager)
    {
        if (enemyManager.CheckOnTarget() >= enemyManager.agroDistance)
        {
            enemyManager.animator.SetBool("is_Angry", false);
            enemyManager.SwitchState(enemyManager.idleState);
        }
        //Debug.Log($"Distance {enemyManager.CheckOnTarget()} {enemyManager.attackDistance}");
        if (enemyManager.CheckOnTarget() <= enemyManager.attackDistance)
        {
            enemyManager.animator.SetBool("is_Angry", true);
            enemyManager.SwitchState(enemyManager.attackState);
        }
    }*/
}
