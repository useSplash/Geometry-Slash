using UnityEngine;

public abstract class PlayerBaseState
{
    public abstract void EnterState(PlayerStateManager playerSM);
    public abstract void UpdateState(PlayerStateManager playerSM);
    public abstract void ExitState(PlayerStateManager playerSM);
}