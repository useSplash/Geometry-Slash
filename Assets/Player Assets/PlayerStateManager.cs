using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
    public PlayerController playerController;

    PlayerBaseState currentState;

    public PlayerIdleState IdleState = new PlayerIdleState();
    public PlayerWalkingState WalkingState = new PlayerWalkingState();
    public PlayerDashingState DashingState = new PlayerDashingState();
    public PlayerSwordAttackingState SwordAttackingState = new PlayerSwordAttackingState();
    public PlayerSwordChargingState SwordChargingState = new PlayerSwordChargingState();

    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<PlayerController>();

        // starting state for the state machine
        currentState = IdleState;
        currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);
    }

    public PlayerBaseState GetCurrentState(){
        return currentState;
    }

    public void SwitchState(PlayerBaseState state) {
        currentState.ExitState(this);
        currentState = state;
        state.EnterState(this);
    }
}
