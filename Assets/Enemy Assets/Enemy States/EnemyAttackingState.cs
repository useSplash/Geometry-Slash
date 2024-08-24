using UnityEngine;

public class EnemyAttackingState : EnemyBaseState
{
    // Do when entering this state
    public override void EnterState(EnemyStateManager sm) {
        Debug.Log("Attacking");
        sm.enemyController.anim.SetBool("Attacking", true);
        sm.enemyController.SetChargeDirection();
        sm.enemyController.rb.velocity = Vector3.zero;
    }

    // Do in this state
    public override void UpdateState(EnemyStateManager sm) {

        if (sm.enemyController.currAnim != "Enemy_Melee_Attack"
            && !sm.enemyController.anim.GetBool("Attacking")) {

            sm.enemyController.attackTimer = sm.enemyController.attackCD;
            sm.SwitchState(sm.ReadyState);
        }

        if (sm.enemyController.currAnim == "Enemy_Melee_Attack") {
            
            sm.enemyController.anim.SetBool("Attacking", false);
        }
    }

    // Do when transitioning to another state
    public override void ExitState(EnemyStateManager sm) {

        sm.enemyController.anim.SetBool("Attacking", false);
    }
}