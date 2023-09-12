using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerGroundedState {

    protected bool dodgeInput = false;
    public PlayerMoveState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName) {

    }

    public override void DoChecks() {
        base.DoChecks();
    }

    public override void Enter() {
        base.Enter();
    }

    public override void Exit() {
        base.Exit();
    }

    public override void LogicUpdate() {
        base.LogicUpdate();

        dodgeInput = player.InputHandler.Dodge;

        if (input.x == 0f && input.y == 0f) {

            stateMachine.SwitchState(player.IdleState);

        } else if (dodgeInput) {

            stateMachine.SwitchState(player.DodgeState);
        }
    }

    public override void PhysicsUpdate() {
        base.PhysicsUpdate();

        player.Move(input);
    }
}
