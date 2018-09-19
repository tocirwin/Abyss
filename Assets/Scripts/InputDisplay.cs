using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputDisplay : MonoBehaviour {

	public InputReciever inputReciever;
	public List<GameObject> buttons = new List<GameObject>();
	private Dictionary<string, GameObject> displayButtons = new Dictionary<string, GameObject>();
	private WaitForSeconds delay = new WaitForSeconds(0.25f);

	void Awake () {
		inputReciever.InputDetected += OnInputDetected;
		inputReciever.InputReleased += OnInputReleased;

		displayButtons.Add("Up", buttons[0]);
		displayButtons.Add("Left", buttons[1]);
		displayButtons.Add("Down", buttons[2]);
		displayButtons.Add("Right", buttons[3]);
		displayButtons.Add("Punch", buttons[4]);
		displayButtons.Add("Kick", buttons[5]);
	}
	
	public void DisplayKey (string key, bool active) {
		GameObject button = displayButtons[key];
		if (active) {
			button.GetComponent<Image>().color = Color.red;
		} else if (!active) {
			button.GetComponent<Image>().color = Color.white;
		}
	}

	public void OnInputDetected (object sender, InputEventArgs e) {
			DisplayKey(e.pressedKey, true);
	}

	public void OnInputReleased (object sender, InputEventArgs e) {
		DisplayKey(e.pressedKey, false);
	}

}
