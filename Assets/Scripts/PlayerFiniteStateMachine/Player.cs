using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This Class holds the Player functions.
 * We want the functions to be placed in this class, 
 *  so that we can call them from the rest of the Finite State Machine.
 * 
 */


public class Player : MonoBehaviour {

    // State Machine Getters & Setters.
    public PlayerStateMachine StateMachine { get; private set; }
    public PlayerIdleState IdleState { get; private set; }
    public PlayerMoveState MoveState { get; private set; }
    public PlayerJumpState JumpState { get; private set; }
    public PlayerDodgeState DodgeState { get; private set; }

    // Public Getters, Private Setters
    public Camera PlayerCam { get; private set; }
    public Animator Anim { get; private set; }
    public PlayerInputHandler InputHandler { get; private set; }
    public Rigidbody RB { get; private set; }
    public Vector3 CurrentVelocity { get; private set; }
    public bool IsDodging { get; private set; }
    public bool CanDodge { get; private set; } = true;
    public bool CanJump { get; private set; } = true;


    // Public Getters, Public Setters
    public bool IsGrounded { get; set; }

    [SerializeField]
    private PlayerData playerData;

    // Player Movement Variables
    private Vector3 velocityWorkspace;
    private Vector3 movingDirection;
    private float playerSpeed;
    private float jumpTimer;
    private float dodgeTimer;

    // Player Rotation Variables
    private Vector3 forwardRelative;
    private Vector3 rightRelative;
    private Vector3 forward;
    private Vector3 right;


    private void Awake() {

        StateMachine = new PlayerStateMachine();

        IdleState = new PlayerIdleState(this, StateMachine, playerData, "idle");
        MoveState = new PlayerMoveState(this, StateMachine, playerData, "move");
        JumpState = new PlayerJumpState(this, StateMachine, playerData, "jump");
        DodgeState = new PlayerDodgeState(this, StateMachine, playerData, "dodge");

    }

    private void Start() {

        PlayerCam = GetComponentInChildren<Camera>();
        Anim = GetComponentInChildren<Animator>();
        InputHandler = GetComponent<PlayerInputHandler>();
        RB = GetComponent<Rigidbody>();

        // Init starting state in player's State Machine.
        StateMachine.Initialize(IdleState);

        playerSpeed = playerData.moveSpeed;

        Debug.Log(CanJump);
    }

    private void Update() {

        CurrentVelocity = RB.velocity;

        ResetActions();

        StateMachine.CurrentState.LogicUpdate();
    }

    private void ResetActions() {
        if (CanJump!) {
            
        }
        if (CanDodge!) {
        
        }
    }

    private void FixedUpdate() {

        StateMachine.CurrentState.PhysicsUpdate();
    }

    private void LateUpdate() {
        
        StateMachine.CurrentState.CameraUpdate();
    }

    // New
    public void Move(Vector2 input) {

        forwardRelative = input.y * forward;
        rightRelative = input.x * right;

        movingDirection = forwardRelative + rightRelative;
        // Apply move speed before setting x and z, or it will apply speed to jump.
        velocityWorkspace = movingDirection * playerSpeed; 
        velocityWorkspace.Set(velocityWorkspace.x, 0, velocityWorkspace.z);      
        velocityWorkspace = (velocityWorkspace - CurrentVelocity);

        RB.AddForce(velocityWorkspace);
    }

    public void SetRotation(Vector2 lookInput) {

        float mouseX = lookInput.x;
        float mouseY = lookInput.y;

        forward = transform.forward;
        right = transform.right;

        forward.y = 0f;
        right.y = 0f;

        // Rotate player.
        transform.Rotate(Vector3.up * (mouseX * Time.deltaTime) * playerData.xSensitivity);
    }

    public void Jump() {

        if (IsGrounded) {
            /*Vector3 jumpForce = Vector3.up * playerData.jumpForce;
            RB.AddForce(jumpForce, ForceMode.VelocityChange);*/

            velocityWorkspace.Set(0, playerData.jumpForce, 0);
            RB.AddForce(velocityWorkspace, ForceMode.VelocityChange);
        }
    }

    public void Dodge() {
      
        IsDodging = true;

        if (IsGrounded) {
            Vector3 dodgeForce = movingDirection * playerData.dodgeForce;
            RB.AddForce(dodgeForce, ForceMode.VelocityChange);
        }
    }

    public void DodgeFinished() {
        
        IsDodging = false;
    }

    public void FlipSprite() {


    }
}
