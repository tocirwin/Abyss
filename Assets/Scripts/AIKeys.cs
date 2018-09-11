using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AIKeys : MonoBehaviour {

	private string[] ValidKeys = new string[] {"Up", "Down", "Left", "Right", "Punch", "Kick"};
	public static List<string> recordedKeys = new List<string>();
	private List<string> nextKeys = new List<string>();
	private int nextKey = 0;

	public event EventHandler<InputEventArgs> ArtificialInputDetected;

	void Awake () {
		for (int i = 0; i < 30; i++) {
			recordedKeys.Add("None");
		}
	}

	void Update () {
		int rolledKey = UnityEngine.Random.Range(0, 7);
		switch (rolledKey) {
			case 0:
			for (int i = 0; i < 30; i++) {
				nextKeys.Add("Left");
			}
			break;
			case 1:
			for (int i = 0; i < 30; i++) {
				nextKeys.Add("Right");
			}
			break;
			case 2:
			for (int i = 0; i < 5; i++) {
				nextKeys.Add("Down");
			}
			break;
			case 3:
			for (int i = 0; i < 5; i++) {
				nextKeys.Add("Up");
			}
			break;
			case 4:
			for (int i = 0; i < 2; i++) {
				nextKeys.Add("Punch");
			}
			break;
			case 5:
			for (int i = 0; i < 2; i++) {
				nextKeys.Add("Kick");
			}
			break;
			case 6:
				nextKeys.Add("Down");
				nextKeys.Add("Right");
				nextKeys.Add("Punch");
			break;
			case 7:
				nextKeys.Add("Down");
				nextKeys.Add("Left");
				nextKeys.Add("Kick");
			break;
		}

		SendKey(nextKeys[nextKey]);
		nextKey++;
	}

	private void SendKey (string key) {
		recordedKeys.Add(key);
		InputEventArgs args = new InputEventArgs();
		args.pressedKey = key;
		args.KeyIndex = recordedKeys.Count - 1;
		ArtificialInputDetected(this, args);
	}

	public List<string> ReturnRecordedKeys () {
		return recordedKeys;
	}

}
