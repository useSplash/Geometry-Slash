using UnityEngine;

public class PlayerWalkingState : PlayerBaseState
{
    float rotationSmooth = 20.0f;
    public override void EnterState(PlayerStateManager playerSM) {
        // Debug.Log("Entered Walking State");
    }

    public override void UpdateState(PlayerStateManager playerSM) {

        if (playerSM.playerController.moveAction.ReadValue<Vector2>().magnitude == 0) {
            playerSM.SwitchState(playerSM.IdleState);
        }

        if (playerSM.playerController.WasPressed(playerSM.playerController.dashAction)) {
            playerSM.SwitchState(playerSM.DashingState);
        }

        if (playerSM.playerController.WasPressed(playerSM.playerController.swordattackAction)) {
            playerSM.SwitchState(playerSM.SwordAttackingState);
        }

        Vector2 direction = HelperFunctions.RotateVector
                (playerSM.playerController.moveAction.ReadValue<Vector2>()
                , -45);
        
        // Moving Player
        playerSM.playerController.playerRB.velocity 
                = new Vector3(direction.x, 0, direction.y) 
                * playerSM.playerController.movementSpeed;

        // Facing Move Direction
        float facingDirection = Vector2.SignedAngle(direction, Vector2.right);
        var rotationVector = playerSM.playerController.transform.rotation.eulerAngles;
        rotationVector.y = facingDirection;
        Quaternion target = Quaternion.Euler(rotationVector);
        if (direction.magnitude > 0) {
            playerSM.playerController.ChangeFacingDirection(target, rotationSmooth);
        }
    }

    public override void ExitState(PlayerStateManager playerSM) {
        // Debug.Log("Exited Walking State");
    }
}