using UnityEngine;

public class EnemyFlinchState : EnemyBaseState
{
    // Do when entering this state
    public override void EnterState(EnemyStateManager sm) {
        Debug.Log("Flinch");
    }

    // Do in this state
    public override void UpdateState(EnemyStateManager sm) {
        
    }

    // Do when transitioning to another state
    public override void ExitState(EnemyStateManager sm) {

    }
}