using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerJumpState : PlayerAirState
{
    public PlayerJumpState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {
    }

    public override void Enter()
    {
        StartAnimation(_stateMachine.Player.AnimationData.JumpParameterHash);

        _stateMachine.JumpForce = _stateMachine.Player.Data.AirData.JumpForce;
        _stateMachine.Player.ForceReceiver.Jump(_stateMachine.JumpForce);
        GameManager.Instance.EffectManager.StopFootStepEffect();

        base.Enter();
    }

    public override void Exit() 
    {
        base.Exit();

        StopAnimation(_stateMachine.Player.AnimationData.JumpParameterHash);
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        if (_stateMachine.Player.Rigidbody.velocity.y <= 0)
        {
            _stateMachine.ChangeState(_stateMachine.FallState);
            return;
        }

    }
}
