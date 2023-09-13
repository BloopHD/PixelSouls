using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDodgeState : PlayerGroundedState {

    public PlayerDodgeState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName) {

    }

    public override void DoChecks() {
        base.DoChecks();
    }

    public override void Enter() {
        base.Enter();

        player.Dodge();
    }

    public override void Exit() {
        base.Exit();

    }

    public override void LogicUpdate() {
        base.LogicUpdate();

        if (player.IsDodging == false) {

            stateMachine.SwitchState(player.MoveState);
        }
    }

    public override void PhysicsUpdate() {
        base.PhysicsUpdate();

    }
}