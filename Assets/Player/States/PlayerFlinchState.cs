using UnityEngine;

public class PlayerFlinchState : PlayerBaseState
{
    float duration = 0.8f;
    float counter;
    public Vector2 flinchDirection;
    
    public override void EnterState(PlayerStateManager playerSM) {
        // Debug.Log("Flinch");
        counter = 0;
        playerSM.playerController.Knockback(flinchDirection);
        playerSM.playerController.playerAnimator.SetBool("Hurt", true);

        var rotationVector = playerSM.playerController.transform.rotation.eulerAngles;
        rotationVector.y = Vector2.SignedAngle(flinchDirection, Vector2.right);
        Quaternion temp = Quaternion.Euler(rotationVector);
        playerSM.playerController.ChangeFacingDirection(temp, 0);
    }

    public override void UpdateState(PlayerStateManager playerSM) {
        if (counter < duration){
            counter += Time.deltaTime;
        }
        else {
            playerSM.SwitchState(playerSM.IdleState);
        }
    }

    public override void ExitState(PlayerStateManager playerSM) {
        playerSM.playerController.playerAnimator.SetBool("Hurt", false);
    }
}