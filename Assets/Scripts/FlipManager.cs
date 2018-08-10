using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipManager : MonoBehaviour {

	public Camera mainCamera;
	public GameObject player1;
	public GameObject player2;
	public List<GameObject> player1HitBoxes = new List<GameObject>();
	public List<GameObject> player2HitBoxes = new List<GameObject>();

	private bool flipped = false;

	void Start() {
		InvokeRepeating("UpdateCameraPos", 0f, 2f);
	}

	private void FlipBoxes () {
		foreach (GameObject hit in player1HitBoxes) {
			Vector3 reverse = hit.transform.localPosition;
			reverse.x = reverse.x * -1;
			hit.transform.localPosition = reverse;
		}
		foreach (GameObject hit in player2HitBoxes) {
			Vector3 reverse = hit.transform.localPosition;
			reverse.x = reverse.x * -1;
			hit.transform.localPosition = reverse;
		}
	}
	
	private void FlipSprites () {
		player1.GetComponent<SpriteRenderer>().flipX = !player1.GetComponent<SpriteRenderer>().flipX;
		player2.GetComponent<SpriteRenderer>().flipX = !player1.GetComponent<SpriteRenderer>().flipX;
	}
	
	// Update is called once per frame
	void Update () {
		switch (flipped)
		{
			case false:
				if (player1.transform.position.x > player2.transform.position.x) {
					flipped = !flipped;
					FlipSprites();
					FlipBoxes();
				}
			break;
			case true:
			if (player1.transform.position.x < player2.transform.position.x) {
					flipped = !flipped;
					FlipSprites();
					FlipBoxes();
				}
			break;
		}
	}

	private void UpdateCameraPos () {
		float newPos = (player1.transform.position.x + player2.transform.position.x)/2;
		//mainCamera.transform.position = new Vector3 (newPos, mainCamera.transform.position.y, mainCamera.transform.position.z);
		StartCoroutine(LerpCamera(newPos));
	}

	private IEnumerator LerpCamera (float newPos) {
		Debug.Log (newPos);
		Vector3 updateVector = new Vector3();
		updateVector = mainCamera.transform.position;
		float adjustAmount = (mainCamera.transform.position.x - newPos)/60;
		for (int i = 0; i < 60; i++) {
			updateVector.x -= adjustAmount;
			updateVector.x = Mathf.Clamp(updateVector.x, -1800, 1800);
			mainCamera.transform.position = updateVector;
			yield return null;
		}
	}
}
