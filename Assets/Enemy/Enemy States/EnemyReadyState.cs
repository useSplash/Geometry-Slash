using UnityEngine;

public class EnemyReadyState : EnemyBaseState
{
    // Do when entering this state
    public override void EnterState(EnemyStateManager sm) {
        // Debug.Log("Ready");
        sm.enemyController.anim.SetBool("Ready", true);
    }

    // Do in this state
    public override void UpdateState(EnemyStateManager sm) {
        if (sm.enemyController.attackTimer <= 0){
            
            sm.SwitchState(sm.AttackingState);
        }

        if (HelperFunctions.FlatDistance(sm.enemyController.transform.position
                                        , sm.enemyController.player.transform.position)
                                        > sm.enemyController.attackRange + 1.0f){
           
            sm.enemyController.anim.SetBool("Ready", false);
            sm.SwitchState(sm.ChaseState);
        }

        if (HelperFunctions.FlatDistance(sm.enemyController.transform.position
                                        , sm.enemyController.player.transform.position)
                                        < 2.0f) {

            sm.enemyController.MoveToTarget(sm.enemyController.player.transform.position,
                                        -sm.enemyController.moveSpeed);
        }
        else {
            sm.enemyController.rb.velocity = Vector3.zero;
        }

        sm.enemyController.FaceTarget(sm.enemyController.player.transform.position);
    }

    // Do when transitioning to another state
    public override void ExitState(EnemyStateManager sm) {
        sm.enemyController.anim.SetBool("Ready", false);
    }
}