using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour {

    public Vector2 MovementInput { get; private set; }
    public Vector2 CameraLook { get; private set; }

    public bool JumpInput { get; private set; }

    public bool Dodge { get; private set; }

    public void OnMoveInput(InputAction.CallbackContext context) {

        MovementInput = context.ReadValue<Vector2>();
    }

    public void OnLookInput(InputAction.CallbackContext context) {

        CameraLook = context.ReadValue<Vector2>();
    }

    public void OnJumpInput(InputAction.CallbackContext context) {

        JumpInput = context.performed;
    }

    public void OnDodgeInput(InputAction.CallbackContext context) {

        if (context.ReadValue<float>() > 0) {
            Dodge = true;
        } else {
            Dodge = false;
        }
    }


}
