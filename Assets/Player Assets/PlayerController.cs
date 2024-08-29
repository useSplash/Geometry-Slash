using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    PlayerInput playerInput;
    [HideInInspector] public InputAction moveAction;
    [HideInInspector] public InputAction dashAction;
    [HideInInspector] public InputAction swordattackAction;
    [HideInInspector] public Rigidbody playerRB;
    PlayerStateManager playerSM;
    [HideInInspector] public Animator playerAnimator;
    public Camera playerCamera;
    AnimatorClipInfo[] animatorInfo;
    [HideInInspector] public string currentAnimation;

    [SerializeField]
    public float movementSpeed;
    [SerializeField]
    public float dashSpeed;
    [SerializeField]
    public float dashDuration;
    public bool isDead;

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

        if (GetComponent<Health>()){
            if (GetComponent<Health>().currHP <= 0 && !isDead){
                Death();
            }
        }

        if (isDead) {
            Time.timeScale = 0.2f;
            return;
        }

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
        
        var rotationVector = transform.rotation.eulerAngles;
        rotationVector.y = facingDirection - 135f;
        Quaternion target = Quaternion.Euler(rotationVector);
        
        ChangeFacingDirection(target, 0);
    }

    public Vector2 GetFacingVector(){

        float radians = ((transform.localEulerAngles.y + 45) * Mathf.Deg2Rad);
        Vector2 facingVector = new Vector2(Mathf.Sin(radians), Mathf.Cos(radians));
        Debug.Log(facingVector);
        return facingVector;
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

    public void Knockback(Vector2 dir){

        // Knocked back at target direction
        playerRB.velocity = new Vector3(dir.x, 0, dir.y)
                    * -5000f
                    * Time.deltaTime;
        Invoke("Stop", 0.05f);
    }

    public void Stop(){
        playerRB.velocity = Vector3.zero;
    }

    public void Death(){
        isDead = true;
        playerAnimator.SetBool("Hurt", false);
        playerInput.actions.Disable();
        playerCamera.GetComponent<CameraFollow>().ChangeZoom(10.0f);
        playerAnimator.Play("Player_Sword_Death");
    }
}
