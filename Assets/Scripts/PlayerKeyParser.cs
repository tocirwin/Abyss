using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerKeyParser : MonoBehaviour {

	private int frameBuffer = 15;
	public InputReciever inputReciever;
	public AIKeys aIKeys;
	public PlayerState playerState;
	private Func<List<KeyCode>> returnKeys;

	private void Start () {
		if (inputReciever) {
			returnKeys = ReturnPlayerKeys;
			inputReciever.InputDetected += OnInputDetected;
		}
		else if (aIKeys) {
			returnKeys = ReturnAIKeys;
			aIKeys.ArtificialInputDetected += OnArtificialInputDetected;
		}
	}

	public void OnInputDetected (object sender, InputEventArgs e) {
		playerState.InvokeMove(ParseKey(e.pressedKey, e.KeyIndex));
	}

	public void OnArtificialInputDetected (object sender, InputEventArgs e) {
		playerState.InvokeMove(ParseKey(e.pressedKey, e.KeyIndex));
	}

	private Moves ParseKey (KeyCode key, int index) {
		Moves currentMove = playerState.ReturnMoveState();
		Moves returnedMove;
		switch (key)
		{
			case KeyCode.Mouse0:
				if (CheckDragonPunch(index)) {
					returnedMove = MoveKeyStates.MoveStateSpecialOutcome(Moves.DragonPunch, currentMove);
					return returnedMove;
				} else if (CheckFireball(index)) {
					returnedMove = MoveKeyStates.MoveStateSpecialOutcome(Moves.Fireball, currentMove);
					return returnedMove;
				} else { goto default; }
			case KeyCode.Mouse1:
				if (CheckTatsu(index)) {
					returnedMove = MoveKeyStates.MoveStateSpecialOutcome(Moves.Tatsu, currentMove);
					return returnedMove;
				} else { goto default; }
			default:
				returnedMove = MoveKeyStates.MoveStateOutcome(key, currentMove);
				return returnedMove;
		}
	}

	private bool CheckFireball (int index) {
		KeyCode toward = KeyCode.D;
		if (!playerState.ReturnFlipState()) {
			toward = KeyCode.D;
		} else if (playerState.ReturnFlipState()) {
			toward = KeyCode.A;
		}
		List<KeyCode> keys = returnKeys();
		for (int i = index; i > index - frameBuffer; i--)
		{
			if (keys[i] == toward) {
				for (int m = i; m > index - frameBuffer; m--)
				{
					if (keys[m] == KeyCode.S) {
						return true;
					}
				}
			}
		}
		return false;
	}

	private bool CheckDragonPunch (int index) {
		KeyCode toward = KeyCode.D;
		if (!playerState.ReturnFlipState()) {
			toward = KeyCode.D;
		} else if (playerState.ReturnFlipState()) {
			toward = KeyCode.A;
		}
		List<KeyCode> keys = returnKeys();
		for (int i = index; i > index - frameBuffer; i--)
		{
			if (keys[i] == toward) {
				for (int m = i; m > index - frameBuffer; m--)
				{
					if (keys[m] == KeyCode.S) {
						for (int s = m; s > index - frameBuffer; s--)
						{
							if (keys[s] == toward) {
								return true;
							}
						}
					}
				}
			}
		}
		return false;
	}

	private bool CheckTatsu (int index) {
		KeyCode away = KeyCode.D;
		if (!playerState.ReturnFlipState()) {
			away = KeyCode.A;
		} else if (playerState.ReturnFlipState()) {
			away = KeyCode.D;
		}
		List<KeyCode> keys = returnKeys();
		for (int i = index; i > index - frameBuffer; i--)
		{
			if (keys[i] == away) {
				for (int m = i; m > index - frameBuffer; m--)
				{
					if (keys[m] == KeyCode.S) {
						return true;
					}
				}
			}
		}
		return false;
	}

	private void CheckThrow (int index) {
		List<KeyCode> keys = returnKeys();
	}

	private List<KeyCode> ReturnPlayerKeys () {
		return inputReciever.ReturnRecordedKeys();
	}

	private List<KeyCode> ReturnAIKeys () {
		return aIKeys.ReturnRecordedKeys();
	}

}
