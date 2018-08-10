using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour {

	public GameObject greenBar;
	public GameObject redBar;
	private RectTransform greenTransform;
	private RectTransform redTransform;
	private WaitForSeconds delay = new WaitForSeconds(0.01f);
	Vector3 drain = new Vector3 (1, 0, 0);

	// Use this for initialization
	void Start () {
		greenTransform = greenBar.GetComponent<RectTransform>();
		redTransform = redBar.GetComponent<RectTransform>();
	}

	public void ReduceHealth (float damage) {
		damage = damage * .6f;
		greenTransform.transform.localPosition += new Vector3 (-damage, 0, 0);
		StartCoroutine(FadeRedHealth(damage));
	}

	public void RestoreHealth (float amount) {
		amount = amount * .6f;
		greenTransform.transform.localPosition += new Vector3 (amount, 0, 0);
		redTransform.transform.localPosition += new Vector3 (amount, 0, 0);
	}

	private IEnumerator FadeRedHealth (float damage) {
		yield return new WaitForSeconds(1f);
		for (int i = 0; i < damage; i++) {
			redTransform.transform.localPosition -= drain;
			yield return delay;
		}
	}

}
