using UnityEngine;

public class EnemyChaseState : EnemyBaseState
{
    // Do when entering this state
    public override void EnterState(EnemyStateManager sm) {
        Debug.Log("Chase");
        sm.enemyController.anim.SetBool("Chasing", true);
    }

    // Do in this state
    public override void UpdateState(EnemyStateManager sm) {
        if (HelperFunctions.FlatDistance(sm.enemyController.transform.position
                                        , sm.enemyController.player.transform.position)
                                        > sm.enemyController.detectRange){
            
            sm.SwitchState(sm.IdleState);
        }
        if (HelperFunctions.FlatDistance(sm.enemyController.transform.position,
                                         sm.enemyController.player.transform.position)
                                                    <= sm.enemyController.attackRange){
            
            sm.SwitchState(sm.ReadyState);
        }

        sm.enemyController.MoveToTarget(sm.enemyController.player.transform.position,
                                        sm.enemyController.moveSpeed);

        sm.enemyController.FaceTarget(sm.enemyController.player.transform.position);
    }

    // Do when transitioning to another state
    public override void ExitState(EnemyStateManager sm) {
        sm.enemyController.anim.SetBool("Chasing", false);
    }
}