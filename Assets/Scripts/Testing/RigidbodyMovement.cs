using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyMovement : MonoBehaviour {

    [SerializeField] private Transform PlayerCamera;
    [SerializeField] private Rigidbody RB;
    [Space]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float JumpForce;
    [SerializeField] private float camSensitivity;

    private Vector3 PlayerMovementInput;
    private Vector3 PlayerMouseInput;

    
    private void Start() {
        
    }

    private void Update() {

        PlayerMovementInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        PlayerMouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        MovePlayer();
        MovePlayerCamera();
    }

    private void MovePlayer() {

        Vector3 MoveVector = transform.TransformDirection(PlayerMovementInput) * moveSpeed;
        RB.velocity = new Vector3(MoveVector.x, RB.velocity.y, MoveVector.z);
    }

    private void MovePlayerCamera() {
        
    }
}
