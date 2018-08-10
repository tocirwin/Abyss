using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCollider : MonoBehaviour {

	private bool playerBlocked = false;
	private bool wallBlocked = false;

	public void OnTriggerEnter2D (Collider2D collider) {
		if (collider.gameObject.layer == 12) {
			playerBlocked = true;
		} else if (collider.gameObject.layer == 13) {
			Debug.Log("Wall Blocked");
			wallBlocked = true;
		}
	}

	public void OnTriggerExit2D (Collider2D collider) {
		if (collider.gameObject.layer == 12) {
			playerBlocked = false;
		} else if (collider.gameObject.layer == 13) {
			wallBlocked = false;
		}
	}

	public bool ReturnPlayerBlocked () {
		return playerBlocked;
	}

	public bool ReturnWallBlocked () {
		return wallBlocked;
	}
}
