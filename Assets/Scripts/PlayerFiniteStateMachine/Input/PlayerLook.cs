using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour {

    [SerializeField] private Camera playerCamera;
    [SerializeField] private float xSensitivity = 30f;
    [SerializeField] private float ySensitivity = 30f;

    private float xRotation = 0f;

    public void ProcessLook(Vector2 lookInput) {

        float mouseX = lookInput.x;
        float mouseY = lookInput.y;

        // Calculate camera rotation for looking up and down.
        xRotation -= (mouseY * Time.deltaTime) * ySensitivity;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f); // Prob wanna mess with these clamp limitations

        // Apply to player camera.
        playerCamera.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        

        // Rotate player.
        transform.Rotate(Vector3.up * (mouseX * Time.deltaTime) * xSensitivity);
    }
}
