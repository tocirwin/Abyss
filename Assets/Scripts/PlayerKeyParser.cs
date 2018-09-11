using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerKeyParser : MonoBehaviour {

	private int frameBuffer = 15;
	public InputReciever inputReciever;
	public AIKeys aIKeys;
	public PlayerState playerState;
	private Func<List<string>> returnKeys;

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

	private Moves ParseKey (string key, int index) {
		Moves currentMove = playerState.ReturnMoveState();
		Moves returnedMove;
		switch (key)
		{
			case "Punch":
				if (CheckDragonPunch(index)) {
					returnedMove = MoveKeyStates.MoveStateSpecialOutcome(Moves.DragonPunch, currentMove);
					return returnedMove;
				} else if (CheckFireball(index)) {
					returnedMove = MoveKeyStates.MoveStateSpecialOutcome(Moves.Fireball, currentMove);
					return returnedMove;
				} else { goto default; }
			case "Kick":
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
		string toward = "Right";
		if (!playerState.ReturnFlipState()) {
			toward = "Right";
		} else if (playerState.ReturnFlipState()) {
			toward = "Left";
		}
		List<string> keys = returnKeys();
		for (int i = index; i > index - frameBuffer; i--)
		{
			if (keys[i] == toward) {
				for (int m = i; m > index - frameBuffer; m--)
				{
					if (keys[m] == "Down") {
						return true;
					}
				}
			}
		}
		return false;
	}

	private bool CheckDragonPunch (int index) {
		string toward = "Right";
		if (!playerState.ReturnFlipState()) {
			toward = "Right";
		} else if (playerState.ReturnFlipState()) {
			toward = "Left";
		}
		List<string> keys = returnKeys();
		for (int i = index; i > index - frameBuffer; i--)
		{
			if (keys[i] == toward) {
				for (int m = i; m > index - frameBuffer; m--)
				{
					if (keys[m] == "Down") {
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
		string away = "Left";
		if (!playerState.ReturnFlipState()) {
			away = "Left";
		} else if (playerState.ReturnFlipState()) {
			away = "Right";
		}
		List<string> keys = returnKeys();
		for (int i = index; i > index - frameBuffer; i--)
		{
			if (keys[i] == away) {
				for (int m = i; m > index - frameBuffer; m--)
				{
					if (keys[m] == "Down") {
						return true;
					}
				}
			}
		}
		return false;
	}

	private void CheckThrow (int index) {
		List<string> keys = returnKeys();
	}

	private List<string> ReturnPlayerKeys () {
		return inputReciever.ReturnRecordedKeys();
	}

	private List<string> ReturnAIKeys () {
		return aIKeys.ReturnRecordedKeys();
	}

}
