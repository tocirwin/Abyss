using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;
using System.ComponentModel;

public class ParticleBackground : MonoBehaviour {

	public List<ParticleSystem> clouds = new List<ParticleSystem>();
	public List<ParticleSystem> fireworks = new List<ParticleSystem>();
	public List<ParticleSystem> dustParticles = new List<ParticleSystem>();
	public GameObject orb;

	public List<GameObject> disabledGameElements = new List<GameObject>();

	private List<ParticleSystem> allParticles = new List<ParticleSystem>();

	void Start () {
		allParticles.AddRange(clouds);
		allParticles.AddRange(fireworks);
		allParticles.AddRange(dustParticles);
		
		RandomizeParticles(clouds, 50, 250);
		RandomizeParticles(fireworks, 1000, 2000);
		RandomizeParticles(dustParticles, 20, 50);
		
		StartCoroutine(ExpandOrb());
	}

	public IEnumerator StartTimer () {
		yield return new WaitForSeconds(2.5f);
		PauseParticles();
		yield return null;
	}

	private void RandomizeParticles (List<ParticleSystem> particles, float min, float max) {
		foreach (ParticleSystem p in particles) {
			var main = p.main;
			main.startColor = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0.5f, 1f));
			main.startSpeed = Random.Range(min, max);
		}
	}

	private IEnumerator ExpandOrb () {
		WaitForSeconds delay = new WaitForSeconds(0.025f);
		for (int i = 1; i < 200; i++) {
			Vector3 scaler = orb.transform.localScale;
			scaler.x -= (50);
			scaler.y -= (50);
			orb.transform.localScale = scaler;
			yield return delay;
		}
		orb.SetActive(false);
		foreach (ParticleSystem item in allParticles) {
			item.Play();
		}
		StartCoroutine(StartTimer());
	}

	private void PauseParticles () {
		foreach (ParticleSystem item in allParticles)
		{
			//item.Pause();
		}
		EnableGameElements();
	}

	private void EnableGameElements () {
		foreach (GameObject item in disabledGameElements) {
			item.SetActive(true);
		}
	}

}
