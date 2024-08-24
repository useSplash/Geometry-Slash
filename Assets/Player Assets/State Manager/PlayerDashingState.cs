using UnityEngine;
using System.Collections;

public class PlayerDashingState : PlayerBaseState
{
    Vector3 direction;
    float counter;
    public override void EnterState(PlayerStateManager playerSM) {
        // Debug.Log("Entered Dashing State");
        counter = 0;
        direction = Vector3.Normalize(playerSM.playerController.playerRB.velocity);
        playerSM.playerController.swordattackAction.Disable();
    }

    public override void UpdateState(PlayerStateManager playerSM) {
        
        playerSM.playerController.playerRB.velocity 
                = direction 
                * playerSM.playerController.dashSpeed;

        if (counter >= playerSM.playerController.dashDuration) {
            playerSM.SwitchState(playerSM.IdleState);
        }
        else {
            counter += Time.deltaTime;
        }
    }

    public override void ExitState(PlayerStateManager playerSM) {
        playerSM.playerController.swordattackAction.Enable();
    }
}