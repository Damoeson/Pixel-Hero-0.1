using UnityEngine;

public class E2_PlayerDetectedState : PlayerDetectedState
{
    private Movement Movement { get => movement ?? core.GetCoreComponent(ref movement); }

    private Movement movement;

    private Enemy2 enemy;

    public E2_PlayerDetectedState(Entity etity, FiniteStateMachine stateMachine, string animBoolName, D_PlayerDetected stateData, Enemy2 enemy) : base(etity, stateMachine, animBoolName, stateData)
    {
        this.enemy = enemy;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (performCloseRangeAction)
        {
            if (Time.time >= enemy.dodgeState.startTime + enemy.dodgeStateData.dodgeCooldown)
            {
                stateMachine.ChangeState(enemy.dodgeState);
            }

            else
            {
                stateMachine.ChangeState(enemy.meleeAttackState);
            }
        }

        else if (performLongRangeAction)
        {
            stateMachine.ChangeState(enemy.rangedAttackState);
        }

        else if (!isDetectingLedge)
        {
            Movement?.Flip();
            stateMachine.ChangeState(enemy.moveState);
        }

        else if (!isPlayerInMaxAgroRange)
        {
            stateMachine.ChangeState(enemy.lookForPlayerState);
        }

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
