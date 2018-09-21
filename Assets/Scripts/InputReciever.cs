using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InputReciever : MonoBehaviour {

	public string haxis;
	public string vaxis;
	public string punch;
	public string kick;

	public event EventHandler<InputEventArgs> InputDetected;
	public event EventHandler<InputEventArgs> InputReleased;

	public bool upActive;
	public bool downActive;
	public bool leftActive;
	public bool rightActive;
	private float axisBuffer = 0.75f;
	public static List<string> recordedKeys = new List<string>();
	string enteredKey = "None";

	void Awake () {
		for (int i = 0; i < 30; i++) {
			recordedKeys.Add("None");
		}
	}

	// Update is called once per frame
	void Update () {
		CheckButtonUp();
		if (Input.GetAxisRaw(haxis) < -axisBuffer) {
			enteredKey = "Left";
			leftActive = true;
		}
		if (Input.GetAxisRaw(haxis) > axisBuffer) {
			enteredKey = "Right";
			rightActive = true;
		}
		if (Input.GetAxisRaw(vaxis) < -axisBuffer) {
			enteredKey = "Up";
			upActive = true;
		}
		if (Input.GetAxisRaw(vaxis) > axisBuffer) {
			enteredKey = "Down";
			downActive = true;
		}
		if (Input.GetButton(punch)) {
			enteredKey = "Punch";
		}
		if (Input.GetButton(kick)) {
			enteredKey = "Kick";
		}
		SendKeyEvent(enteredKey);
		enteredKey = "None";
	}

	private void CheckButtonUp () {
		if (Math.Abs(Input.GetAxisRaw(haxis)) < 1f) {
			if (leftActive) {
				SendKeyDownEvent("Left");
				leftActive = false;
			}
			if (rightActive) {
				SendKeyDownEvent("Right");
				rightActive = false;
			}
		}
		if (Math.Abs(Input.GetAxisRaw(vaxis)) < 1f) {
			if (upActive) {
				SendKeyDownEvent("Up");
				upActive = false;
			}
			if (downActive) {
				SendKeyDownEvent("Down");
				downActive = false;
			}
		}
		if (Input.GetButtonUp(kick)) {
			SendKeyDownEvent("Kick");
		}
		if (Input.GetButtonUp(punch)) {
			SendKeyDownEvent("Punch");
		}
	}

	private void SendKeyEvent (string key) {
		recordedKeys.Add(key);
		if (key != "None") {
			InputEventArgs args = new InputEventArgs();
			args.pressedKey = key;
			args.KeyIndex = recordedKeys.Count - 1;
			InputDetected(this, args);
		}
	}

	private void SendKeyDownEvent (string key) {
		if (key != "None") {
			InputEventArgs args = new InputEventArgs();
			args.pressedKey = key;
			InputReleased(this, args);
		}
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
