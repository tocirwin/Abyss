using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputDisplay : MonoBehaviour {

	public InputReciever inputReciever;
	public List<GameObject> buttons = new List<GameObject>();
	private Dictionary<KeyCode, GameObject> displayButtons = new Dictionary<KeyCode, GameObject>();
	private WaitForSeconds delay = new WaitForSeconds(0.25f);

	void Awake () {
		inputReciever.InputDetected += OnInputDetected;
		inputReciever.InputReleased += OnInputReleased;

		displayButtons.Add(KeyCode.W, buttons[0]);
		displayButtons.Add(KeyCode.A, buttons[1]);
		displayButtons.Add(KeyCode.S, buttons[2]);
		displayButtons.Add(KeyCode.D, buttons[3]);
		displayButtons.Add(KeyCode.Mouse0, buttons[4]);
		displayButtons.Add(KeyCode.Mouse1, buttons[5]);
	}
	
	public void DisplayKey (KeyCode key, bool active) {
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
