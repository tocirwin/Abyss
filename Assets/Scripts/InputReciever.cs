using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InputReciever : MonoBehaviour {

	public event EventHandler<InputEventArgs> InputDetected;
	public event EventHandler<InputEventArgs> InputReleased;

	private string[] ValidKeys = new string[] {"Up", "Left", "Right", "Down", "Punch", "Kick"};
	private string[] ValidMoveKeys = new string[] {"Up", "Left", "Right", "Down"};
	private string[] ValidAttackKeys = new string[] {"Punch", "Kick"};
	public static List<string> recordedKeys = new List<string>();

	void Awake () {
		for (int i = 0; i < 30; i++) {
			recordedKeys.Add("None");
		}
	}

	// Update is called once per frame
	void Update () {
		if (Input.anyKey) {
			foreach (string key in ValidMoveKeys)
			{
				if (Input.GetButton(key)) {
					recordedKeys.Add(key);
					InputEventArgs args = new InputEventArgs();
					args.pressedKey = key;
					args.KeyIndex = recordedKeys.Count - 1;
					InputDetected(this, args);
				}
			}
			foreach (string key in ValidAttackKeys) {
				if (Input.GetButton(key)) {
					recordedKeys.Add(key);
					InputEventArgs args = new InputEventArgs();
					args.pressedKey = key;
					args.KeyIndex = recordedKeys.Count - 1;
					InputDetected(this, args);
				}
			}
		} else {
			recordedKeys.Add("None");
		}

		for (int i = 0; i < ValidKeys.Length; i++)
		{
			if (Input.GetButtonUp(ValidKeys[i])) {
				InputEventArgs args = new InputEventArgs();
				args.pressedKey = ValidKeys[i];
				InputReleased(this, args);
			}
		}

	}

	public List<string> ReturnRecordedKeys () {
		return recordedKeys;
	}

}
