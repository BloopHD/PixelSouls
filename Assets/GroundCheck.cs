using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour {

    [SerializeField]
    private Player player;
    [SerializeField]
    private GameObject groundTagObject;

    private string groundTagString;

    private void Awake() {
        player = GetComponentInParent<Player>();

        groundTagString = groundTagObject.name;
    }

    private void OnTriggerEnter(Collider other) {

        Debug.Log(groundTagString);
        Debug.Log(other.gameObject.tag);

        if (other.gameObject ==  player.gameObject) {
            return;
        } else if (other.gameObject.tag == groundTagString) {
            player.IsGrounded = true;
        }
    }

    private void OnTriggerExit(Collider other) {

        if (other.gameObject == player.gameObject) {
            return;
        } else if (other.gameObject.tag == groundTagString) {
            player.IsGrounded = false;
        }
    }

    private void OnTriggerStay(Collider other) {

        if (other.gameObject == player.gameObject) {
            return;
        } else if (other.gameObject.tag == groundTagString) {
            player.IsGrounded = true;
        }
    }
}
