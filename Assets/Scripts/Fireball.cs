using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour {

	public Vector3 speed = new Vector3(10, 0, 0);
	//public int damage;
	public List<ParticleSystem> particles = new List<ParticleSystem>();

	// Use this for initialization
	void Start () {
		Invoke("Expire", 5f);
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += speed;
	}

	public void flipDirection () {
		speed = new Vector3(-10, 0, 0);
		GetComponent<SpriteRenderer>().flipX = true;
		foreach (ParticleSystem p in particles) {
			float pos = p.transform.localPosition.x;
			Vector3 newPos = new Vector3(-p.transform.localPosition.x, p.transform.localPosition.y, p.transform.localPosition.z);
			p.transform.localPosition = newPos;
		}
	}

	private void Expire () {
		Destroy(gameObject);
	}

	public void Explode () {
		GetComponent<SpriteRenderer>().enabled = false;
		speed = Vector3.zero;
		foreach (ParticleSystem p in particles) {
			p.Play();
		}
		Destroy(gameObject, 0.4f);
	}

}
