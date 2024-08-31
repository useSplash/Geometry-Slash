using UnityEngine;

public class EnemyIdleState : EnemyBaseState
{
    // Do when entering this state
    public override void EnterState(EnemyStateManager sm) {
        
    }

    // Do in this state
    public override void UpdateState(EnemyStateManager sm) {
        if (HelperFunctions.FlatDistance(sm.enemyController.transform.position
                                        , sm.enemyController.player.transform.position)
                                        < sm.enemyController.detectRange){
            
            sm.SwitchState(sm.ChaseState);
        }
        sm.enemyController.rb.velocity = Vector3.zero;
    }

    // Do when transitioning to another state
    public override void ExitState(EnemyStateManager sm) {

    }
}