using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    PlayerInput playerInput;
    public InputAction moveAction;
    public InputAction dashAction;
    public InputAction swordattackAction;
    public Rigidbody playerRB;
    PlayerStateManager playerSM;
    public Animator playerAnimator;
    public Camera playerCamera;
    AnimatorClipInfo[] animatorInfo;
    public string currentAnimation;

    [SerializeField]
    public float movementSpeed;
    [SerializeField]
    public float dashSpeed;
    [SerializeField]
    public float dashDuration;

    // Start is called before the first frame update
    void Start()
    {
        // INPUT SYSTEM
        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions.FindAction("Move");
        dashAction = playerInput.actions.FindAction("Dash");
        swordattackAction = playerInput.actions.FindAction("Attack (Sword)");

        playerRB = GetComponent<Rigidbody>();
        playerSM = GetComponent<PlayerStateManager>();
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animatorInfo = playerAnimator.GetCurrentAnimatorClipInfo(0);
        currentAnimation = animatorInfo[0].clip.name;
        // Debug.Log(currentAnimation);

        playerAnimator.SetFloat("Move Input", 
            moveAction.ReadValue<Vector2>().magnitude);
        
        playerAnimator.SetBool("Attack Command", 
            IsPressed(swordattackAction));
    }
    
    // Change facing direction of player, 
    // if smooth = 0 then face direction immediately
    public void ChangeFacingDirection(Quaternion target, float smooth){
        if (smooth > 0) {
            transform.rotation = Quaternion.Slerp(transform.rotation, 
                                                    target,
                                                    Time.deltaTime * smooth);
        }
        else {
            transform.rotation = target;
        }
    }

    public void FaceMouse(){
        float directionX = playerCamera.WorldToScreenPoint(this.transform.position).x - Input.mousePosition.x;
        float directionY = playerCamera.WorldToScreenPoint(this.transform.position).y - Input.mousePosition.y;
        
        Vector2 direction = new Vector2(directionX, directionY).normalized;
        float facingDirection = Vector2.SignedAngle(direction, Vector2.right);
        
        var rotationVector = playerSM.playerController.transform.rotation.eulerAngles;
        rotationVector.y = facingDirection - 135f;
        Quaternion target = Quaternion.Euler(rotationVector);
        
        playerSM.playerController.ChangeFacingDirection(target, 0);
    }

    // If the corresponding input was triggered
    public bool WasPressed(InputAction action){
        return action.triggered && action.ReadValue<float>() > 0;
    }
    
    // If the corresponding input is held
    public bool IsPressed(InputAction action){
        return action.ReadValue<float>() > 0;
    }

    // If the corresponding input was released
    public bool WasReleased(InputAction action){
        return action.triggered && action.ReadValue<float>() == default;
    }
}
