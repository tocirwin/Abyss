using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour {

	public List<GameObject> grounds = new List<GameObject>();

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		UpdateGround(grounds[0], 5);
		UpdateGround(grounds[1], 2);
		UpdateGround(grounds[2], 1);
	}

	private void UpdateGround (GameObject ground, int rate) {
		Vector3 groundPos = ground.transform.position;
		groundPos.x = (transform.position.x/rate);
		ground.transform.position = groundPos;
	}
}
