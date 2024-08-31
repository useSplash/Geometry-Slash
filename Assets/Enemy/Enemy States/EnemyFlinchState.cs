using UnityEngine;

public class EnemyFlinchState : EnemyBaseState
{
    float duration = 0.5f;
    float counter;
    public Vector2 flinchDirection;

    // Do when entering this state
    public override void EnterState(EnemyStateManager sm) {
        // Debug.Log("Flinch");
        counter = 0;
        sm.enemyController.Knockback(flinchDirection);
        sm.enemyController.anim.SetBool("Hurt", true);
    }

    // Do in this state
    public override void UpdateState(EnemyStateManager sm) {
        if (counter < duration){
            counter += Time.deltaTime;
        }
        else {
            sm.SwitchState(sm.IdleState);
        }
    }

    // Do when transitioning to another state
    public override void ExitState(EnemyStateManager sm) {
        sm.enemyController.anim.SetBool("Hurt", false);
    }
}