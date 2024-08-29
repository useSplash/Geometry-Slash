using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateManager : MonoBehaviour
{
    [HideInInspector]
    public EnemyController enemyController;
    public EnemyBaseState currentState;
    public EnemyBaseState attackingState;

    public EnemyBaseState StartState;

    public EnemyIdleState IdleState = new EnemyIdleState();
    public EnemyChaseState ChaseState = new EnemyChaseState();
    public EnemyAttackingState AttackingState = new EnemyAttackingState();
    public EnemyReadyState ReadyState = new EnemyReadyState();
    public EnemyFlinchState FlinchState = new EnemyFlinchState();

    // Start is called before the first frame update
    void Start()
    {
        enemyController = GetComponent<EnemyController>();

        // starting state for the state machine
        currentState = IdleState;
        currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyController.isDead) return;
        currentState.UpdateState(this);
    }

    public void SwitchState(EnemyBaseState state) {
        currentState.ExitState(this);
        currentState = state;
        state.EnterState(this);
    }

    public void Flinch(){
        if (enemyController.isDead) return;
        if (currentState != AttackingState) {
            SwitchState(FlinchState);
        }
    }

    public void SetFlinchDirection(Vector2 dir){
        FlinchState.flinchDirection = dir;
    }
}