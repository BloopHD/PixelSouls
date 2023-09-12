using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour {

    [SerializeField]
    private Player player;
    [SerializeField]
    LayerMask groundLayer;

    private void Awake() {
        player = GetComponentInParent<Player>();
    }

    private void OnTriggerEnter(Collider other) {
        
        if (other.gameObject ==  player.gameObject) {
            return;
        } else {
            player.IsGrounded = true;
        }
    }

    private void OnTriggerExit(Collider other) {

        if (other.gameObject == player.gameObject) {
            return;
        } else {
            player.IsGrounded = false;
        }
    }

    private void OnTriggerStay(Collider other) {

        if (other.gameObject == player.gameObject) {
            return;
        } else {
            player.IsGrounded = true;
        }
    }
}
