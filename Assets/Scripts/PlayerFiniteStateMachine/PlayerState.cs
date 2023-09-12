using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState {

    protected Player player;
    protected PlayerStateMachine stateMachine;
    protected PlayerData playerData;

    // IDK if I need these.
    protected float startTime;
    private string animBoolName;

    protected Vector2 look;
    protected bool jump;

    public PlayerState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) {

        this.player = player;
        this.stateMachine = stateMachine;
        this.playerData = playerData;
        this.animBoolName = animBoolName;
    }

    public virtual void Enter() {

        DoChecks();
        player.Anim.SetBool(animBoolName, true);
        startTime = Time.time;

        Debug.LogWarning(animBoolName);
    }

    public virtual void Exit() {

        player.Anim.SetBool(animBoolName, false);
    }

    public virtual void LogicUpdate() {

    }

    public virtual void PhysicsUpdate() {

        DoChecks();

        // Moved to CameraUpdate IE LateUpdate.
        /*look = player.InputHandler.CameraLook;
        player.SetRotation(look);*/       
        
    }

    public virtual void CameraUpdate() {

        look = player.InputHandler.CameraLook;
        player.SetRotation(look);
    }

    // IDK if I need.
    public virtual void DoChecks() {

    }
}
