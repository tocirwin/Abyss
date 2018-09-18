using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InputReciever : MonoBehaviour {

	public event EventHandler<InputEventArgs> InputDetected;
	public event EventHandler<InputEventArgs> InputReleased;

	private bool upActive;
	private bool downActive;
	private bool leftActive;
	private bool rightActive;
	private float axisBuffer = 0.75f;
	public static List<string> recordedKeys = new List<string>();
	int index;

	void Awake () {
		for (int i = 0; i < 30; i++) {
			recordedKeys.Add("None");
		}
	}

	// Update is called once per frame
	void Update () {
		index = recordedKeys.Count;
		if (Input.GetAxisRaw("Horizontal") < -axisBuffer) {
			SendKeyEvent("Left");
			leftActive = true;
		}
		if (Input.GetAxisRaw("Horizontal") > axisBuffer) {
			SendKeyEvent("Right");
			rightActive = true;
		}
		if (Input.GetAxisRaw("Vertical") < -axisBuffer) {
			SendKeyEvent("Up");
			downActive = true;
		}
		if (Input.GetAxisRaw("Vertical") > axisBuffer) {
			SendKeyEvent("Down");
			upActive = true;
		}
		if (Input.GetButton("Punch")) {
			SendKeyEvent("Punch");
		}
		if (Input.GetButtonUp("Punch")) {
			SendKeyDownEvent("Punch");
		}
		else if (Input.GetButton("Kick")) {
			SendKeyEvent("Kick");
		}
		if (Input.GetButtonUp("Kick")) {
			SendKeyDownEvent("Kick");
		}
		if (index == recordedKeys.Count) {
			recordedKeys.Add("None");
		}
	}

	private void SendKeyEvent (string key) {
		recordedKeys.Add(key);
		InputEventArgs args = new InputEventArgs();
		args.pressedKey = key;
		args.KeyIndex = recordedKeys.Count - 1;
		InputDetected(this, args);
	}

	private void SendKeyDownEvent (string key) {
		InputEventArgs args = new InputEventArgs();
		args.pressedKey = key;
		InputReleased(this, args);
	}

	private void RecordKey (string key) {
		recordedKeys.Add(key);
		InputEventArgs args = new InputEventArgs();
		args.pressedKey = key;
		args.KeyIndex = recordedKeys.Count - 1;
		InputDetected(this, args);
	}

	public List<string> ReturnRecordedKeys () {
		return recordedKeys;
	}

}
