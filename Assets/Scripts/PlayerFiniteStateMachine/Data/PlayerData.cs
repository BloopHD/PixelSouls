using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newPlayerData", menuName = "Data/Player Data/Base Data")]


public class PlayerData : ScriptableObject {

    [Header("Camera Movement Settings")]
    public float xSensitivity = 30f;
    public float ySensitivity = 30f;
    public float lookDownClamp = -5f;
    public float lookUpClamp = 20f;

    [Header("Player Movement Settings")]
/*    public float movementVelocity = 5f;
    public float dodgeMultiplier = 2f;
    
    public float moveSensitivity = 0.1f;
    public float moveMaxForce = 1f;*/

    // Used Currently
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public float jumpTimer = 2f;
    public float dodgeForce = 5f;
    public float dodgeTimer = 2f;

}
