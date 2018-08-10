using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

	public GameObject healthBar;
	private HealthBar bar;
	private bool dying = false;
	private int _health;
	public int Health
	{
		get { return _health;}
		set
		{
			_health = value;
			if (_health <= 0) {
				if (!dying) {
					dying = true;
					Die();
				}
			}
		}
	}

	void Start () {
		bar = healthBar.GetComponent<HealthBar>();
	}

	public void TakeDamage (int damage) {
		Health -= damage;
		bar.ReduceHealth(damage);
	}

	public void IncreaseHealth (int amount) {
		Health += amount;
		bar.RestoreHealth(amount);
	}

	public void Die () {
		if (GetComponent<AIKeys>()) {
			GetComponent<AIKeys>().enabled = false;
			StartCoroutine(FadeSprite());
		} else {
			healthBar.transform.parent.GetComponentInChildren<InputReciever>().enabled = false;
			StartCoroutine(FadeSprite());
		}
	}

	private IEnumerator FadeSprite () {
		SpriteRenderer sprite = GetComponent<SpriteRenderer>();
		Color alpha = sprite.color;
		Debug.Log(alpha.a);
		for (float i = 10; i >= 0; i--) {
			Debug.Log (i/10);
			alpha.a = i/10;
			sprite.color = alpha;
			yield return new WaitForSeconds(0.25f);
		}
		yield return new WaitForSeconds(1f);
		LoadHighScore();
	}

	private void LoadHighScore () {
		SceneChanger.LoadNewScene("HighScore", this.name);
	}

	public void EvolveHealth (float newTotalHealth) {
		Health = (int)newTotalHealth;
	}
}
