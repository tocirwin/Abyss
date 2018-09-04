using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour {
	
	private PlayerAnimator playerAnimator;
	private PlayerState playerState;
	private PlayerStats playerStats;
	public MoveCollider leftCollider;
	public MoveCollider rightCollider;

	public WaitForSeconds hangTime = new WaitForSeconds(0.1f);

	private Dictionary<Moves, Func<IEnumerator>> functions = new Dictionary<Moves, Func<IEnumerator>>();

	void Awake () {
		playerAnimator = GetComponent<PlayerAnimator>();
		playerState = GetComponent<PlayerState>();
		playerStats = GetComponent<PlayerStats>();
	}

	void Start () {
		functions.Add(Moves.JumpNeutral, Jump);
		functions.Add(Moves.JumpLeft, Jump);
		functions.Add(Moves.JumpRight, Jump);
		functions.Add(Moves.WalkLeft, MoveLeft);
		functions.Add(Moves.WalkRight, MoveRight);
		functions.Add(Moves.Crouch, Crouch);
		functions.Add(Moves.CrouchLeft, Crouch);
		functions.Add(Moves.CrouchRight, Crouch);
	}

	public void ReceiveMove (Moves move) {
		Func<IEnumerator> f = functions[move];
		StartCoroutine(f());
	}

	private IEnumerator Jump() {
		Vector2 up = new Vector2(0, playerStats.CurrentJumpHeight);
		Vector2 down = new Vector2(0, -playerStats.CurrentJumpHeight);
		if (Input.GetKey(KeyCode.A)) {
			playerState.SetStateTimer(Moves.JumpLeft, 75);
			up.x = -playerStats.CurrentJumpDistance;
			down.x = -playerStats.CurrentJumpDistance;
		}
		else if (Input.GetKey(KeyCode.D)) {
			playerState.SetStateTimer(Moves.JumpRight, 75);
			up.x = playerStats.CurrentJumpDistance;
			down.x = playerStats.CurrentJumpDistance;
		}
		else {
			playerState.SetStateTimer(Moves.JumpNeutral, 75);
		}

        for (int i = 0; i < playerStats.CurrentJumpDuration; i++)
        {
			if (leftCollider.ReturnWallBlocked() || rightCollider.ReturnWallBlocked()) {
				up.x = 0;
				down.x = 0;
			}
            transform.position += ((Vector3)up);
            yield return null;
        }
        yield return new WaitForSeconds(0.1f);
        for (int i = 0; i < playerStats.CurrentJumpDuration; i++)
        {
			if (leftCollider.ReturnWallBlocked() || rightCollider.ReturnWallBlocked()) {
				up.x = 0;
				down.x = 0;
			}
            transform.position += ((Vector3)down);
            yield return null;
        }
    }

	private IEnumerator MoveRight () {
		if (playerState.ReturnFlipState()) {
			playerState.SetStateTimer(Moves.WalkLeft, 5);
		} else {
			playerState.SetStateTimer(Moves.WalkRight, 5);
		}
		if (!rightCollider.ReturnPlayerBlocked() && !rightCollider.ReturnWallBlocked()) {
			transform.Translate(Vector2.right * Time.deltaTime * playerStats.CurrentForwardSpeed);
			yield return null;
		}
	}

	private IEnumerator MoveLeft () {
		if (playerState.ReturnFlipState()) {
			playerState.SetStateTimer(Moves.WalkRight, 5);
		} else {
			playerState.SetStateTimer(Moves.WalkLeft, 5);
		}
		if (!leftCollider.ReturnPlayerBlocked() && !leftCollider.ReturnWallBlocked()) {
			transform.Translate(Vector2.left * Time.deltaTime * playerStats.CurrentForwardSpeed);
			yield return null;
		}
	}

	private IEnumerator Crouch () {
		if (Input.GetKey(KeyCode.A)) {
			playerState.SetStateTimer(Moves.CrouchLeft, 3);
		} else if (Input.GetKey(KeyCode.D)) {
			playerState.SetStateTimer(Moves.CrouchRight, 3);
		} else {
			playerState.SetStateTimer(Moves.Crouch, 3);
		}
		yield return null;
	}

}
