using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{

    public override void EnterState(PlayerStateManager playerSM) {
        // Debug.Log("Entered Idle State");
        playerSM.playerController.playerRB.velocity 
                = Vector3.zero;
    }

    public override void UpdateState(PlayerStateManager playerSM) {

        if (playerSM.playerController.moveAction.ReadValue<Vector2>().magnitude > 0) {
            playerSM.SwitchState(playerSM.WalkingState);
        }

        if (playerSM.playerController.WasPressed(playerSM.playerController.swordattackAction)) {
            playerSM.SwitchState(playerSM.SwordAttackingState);
        }
    }

    public override void ExitState(PlayerStateManager playerSM) {
        // Debug.Log("Exited Idle State");
    }
}