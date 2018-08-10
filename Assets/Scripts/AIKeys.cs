using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AIKeys : MonoBehaviour {

	private KeyCode[] ValidKeys = new KeyCode[] {KeyCode.W, KeyCode.A, KeyCode.S, KeyCode.D, KeyCode.Mouse0, KeyCode.Mouse1};
	public static List<KeyCode> recordedKeys = new List<KeyCode>();
	private List<KeyCode> nextKeys = new List<KeyCode>();
	private int nextKey = 0;

	public event EventHandler<InputEventArgs> ArtificialInputDetected;

	void Awake () {
		for (int i = 0; i < 30; i++) {
			recordedKeys.Add(KeyCode.None);
		}
	}

	void Update () {
		int rolledKey = UnityEngine.Random.Range(0, 7);
		switch (rolledKey) {
			case 0:
			for (int i = 0; i < 30; i++) {
				nextKeys.Add(KeyCode.A);
			}
			break;
			case 1:
			for (int i = 0; i < 30; i++) {
				nextKeys.Add(KeyCode.D);
			}
			break;
			case 2:
			for (int i = 0; i < 5; i++) {
				nextKeys.Add(KeyCode.S);
			}
			break;
			case 3:
			for (int i = 0; i < 5; i++) {
				nextKeys.Add(KeyCode.W);
			}
			break;
			case 4:
			for (int i = 0; i < 2; i++) {
				nextKeys.Add(KeyCode.Mouse0);
			}
			break;
			case 5:
			for (int i = 0; i < 2; i++) {
				nextKeys.Add(KeyCode.Mouse1);
			}
			break;
			case 6:
				nextKeys.Add(KeyCode.S);
				nextKeys.Add(KeyCode.D);
				nextKeys.Add(KeyCode.Mouse0);
			break;
			case 7:
				nextKeys.Add(KeyCode.S);
				nextKeys.Add(KeyCode.A);
				nextKeys.Add(KeyCode.Mouse0);
			break;
		}

		SendKey(nextKeys[nextKey]);
		nextKey++;
	}

	private void SendKey (KeyCode key) {
		recordedKeys.Add(key);
		InputEventArgs args = new InputEventArgs();
		args.pressedKey = key;
		args.KeyIndex = recordedKeys.Count - 1;
		ArtificialInputDetected(this, args);
	}

	public List<KeyCode> ReturnRecordedKeys () {
		return recordedKeys;
	}

}
