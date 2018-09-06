using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InputReciever : MonoBehaviour {

	public event EventHandler<InputEventArgs> InputDetected;
	public event EventHandler<InputEventArgs> InputReleased;
	private KeyCode[] ValidKeys = new KeyCode[] {KeyCode.W, KeyCode.A, KeyCode.S, KeyCode.D, KeyCode.Mouse0, KeyCode.Mouse1};
	private KeyCode[] ValidMoveKeys = new KeyCode[] {KeyCode.W, KeyCode.A, KeyCode.S, KeyCode.D};
	private KeyCode[] ValidAttackKeys = new KeyCode[] {KeyCode.Mouse0, KeyCode.Mouse1};
	public static List<KeyCode> recordedKeys = new List<KeyCode>();
	
	void Awake () {
		for (int i = 0; i < 30; i++) {
			recordedKeys.Add(KeyCode.None);
		}
	}

	// Update is called once per frame
	void Update () {
		if (Input.anyKey) {
			foreach (KeyCode key in ValidMoveKeys)
			{
				if (Input.GetKey(key)) {
					recordedKeys.Add(key);
					InputEventArgs args = new InputEventArgs();
					args.pressedKey = key;
					args.KeyIndex = recordedKeys.Count - 1;
					InputDetected(this, args);
				}
			}
			foreach (KeyCode key in ValidAttackKeys) {
				if (Input.GetKeyDown(key)) {
					recordedKeys.Add(key);
					InputEventArgs args = new InputEventArgs();
					args.pressedKey = key;
					args.KeyIndex = recordedKeys.Count - 1;
					InputDetected(this, args);
				}
			}
		} else {
			recordedKeys.Add(KeyCode.None);
		}

		for (int i = 0; i < ValidKeys.Length; i++)
		{
			if (Input.GetKeyUp(ValidKeys[i])) {
				InputEventArgs args = new InputEventArgs();
				args.pressedKey = ValidKeys[i];
				InputReleased(this, args);
			}
		}

		if (Input.GetButtonDown("Left")) {
			Debug.Log("Left detected");
		}

	}

	public List<KeyCode> ReturnRecordedKeys () {
		return recordedKeys;
	}

}
