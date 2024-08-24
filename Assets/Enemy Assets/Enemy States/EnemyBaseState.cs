using UnityEngine;

public abstract class EnemyBaseState
{
    public abstract void EnterState(EnemyStateManager sm);
    public abstract void UpdateState(EnemyStateManager sm);
    public abstract void ExitState(EnemyStateManager sm);
}