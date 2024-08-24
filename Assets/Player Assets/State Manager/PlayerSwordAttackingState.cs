using UnityEngine;

public class PlayerSwordAttackingState : PlayerBaseState
{
    float chargeBuffer = 0.8f;
    float chargeBufferCount;
    public override void EnterState(PlayerStateManager playerSM) {
        
        chargeBufferCount = 0;
        playerSM.playerController.FaceMouse();
        playerSM.playerController.playerAnimator.ResetTrigger("Attack");
        playerSM.playerController.playerAnimator.SetTrigger("Attack");
    }

    public override void UpdateState(PlayerStateManager playerSM) {
        
        if (playerSM.playerController.currentAnimation == "Player_Sword_Idle" 
            && !playerSM.playerController.IsPressed(playerSM.playerController.swordattackAction)) {

            playerSM.SwitchState(playerSM.IdleState);
        }

        Vector2 direction = HelperFunctions.RotateVector
                (playerSM.playerController.moveAction.ReadValue<Vector2>()
                , -45);
        
        if (playerSM.playerController.WasPressed(playerSM.playerController.swordattackAction)) {

            playerSM.playerController.FaceMouse();
            playerSM.playerController.playerAnimator.ResetTrigger("Attack");
            playerSM.playerController.playerAnimator.SetTrigger("Attack");
        }

        if (playerSM.playerController.IsPressed(playerSM.playerController.swordattackAction)) {
            
            chargeBufferCount += Time.deltaTime;
            // Debug.Log(chargeBufferCount);
            
            if (chargeBufferCount >= chargeBuffer) {
                playerSM.SwitchState(playerSM.SwordChargingState);
            }
        }
        else {
            chargeBufferCount = 0;
        }

        // Moving Player
        playerSM.playerController.playerRB.velocity 
                = new Vector3(direction.x, 0, direction.y) 
                * playerSM.playerController.movementSpeed * 0.1f;
    }

    public override void ExitState(PlayerStateManager playerSM) {

        // Debug.Log("Exited Attacking State");
    }
}