using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerGroundedState {
    public PlayerIdleState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName) {

    }

    public override void DoChecks() {
        base.DoChecks();
    }

    public override void Enter() {
        base.Enter();

        //player.SetVelocity(0f, 0f);
        player.Move(new Vector2(0f, 0f));
    }

    public override void Exit() {
        base.Exit();
    }

    public override void LogicUpdate() {
        base.LogicUpdate();

        player.Move(new Vector2(0f, 0f));

        if (input.x != 0f || input.y != 0f) {

            stateMachine.SwitchState(player.MoveState);
        }
    }

    public override void PhysicsUpdate() {
        base.PhysicsUpdate();
    }
}
