using UnityEngine;

public class PlayerSwordChargingState : PlayerBaseState
{

    public override void EnterState(PlayerStateManager playerSM) {
        playerSM.playerController.playerAnimator.SetBool("Charging", true);
    }

    public override void UpdateState(PlayerStateManager playerSM) {
        playerSM.playerController.playerRB.velocity 
                = Vector3.zero;
        if (!playerSM.playerController.IsPressed(playerSM.playerController.swordattackAction)) {

            playerSM.playerController.playerAnimator.SetBool("Charging", false);
        }
        else if (playerSM.playerController.playerAnimator.GetBool("Charging")){

            playerSM.playerController.FaceMouse();
        }

        if (playerSM.playerController.currentAnimation == "Player_Sword_Idle") {

            playerSM.SwitchState(playerSM.IdleState);
        }
    }

    public override void ExitState(PlayerStateManager playerSM) {
        playerSM.playerController.playerAnimator.SetBool("Charging", false);
    }
}