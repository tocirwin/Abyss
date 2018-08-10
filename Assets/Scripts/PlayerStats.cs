using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

	private int EvolutionLevel = 0;
	private PlayerHealth playerHealth;

	[HideInInspector]
	public float CurrentHealth;
	[HideInInspector]
	public float CurrentForwardSpeed;
	[HideInInspector]
	public float CurrentbBackwardSpeed;
	[HideInInspector]
	public float CurrentJumpDuration;
	[HideInInspector]
	public float CurrentJumpHeight;
	[HideInInspector]
	public float CurrentJumpDistance;

	public float StartingHealth = 1000;
	public float StartingForwardSpeed = 400;
	public float StartingbBackwardSpeed = 400;
	public float StartingJumpDuration = 30;
	public float StartingJumpHeight = 10;
	public float StartingJumpDistance = 3;

	// Use this for initialization
	void Awake () {
		EvolveUpdate (Characters.CharacterStatsDictionary[CharNames.N]);
	}

	void Start () {
		playerHealth = GetComponent<PlayerHealth>();
		playerHealth.EvolveHealth (CurrentHealth);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void EvolveUpdate (CharacterProperties props) {
		CurrentHealth = props.health * StartingHealth;
		CurrentForwardSpeed = props.forwardSpeed * StartingForwardSpeed;
		CurrentbBackwardSpeed = props.backwardSpeed * StartingbBackwardSpeed;
		CurrentJumpDuration = props.jumpDuration * StartingJumpDuration;
		CurrentJumpHeight = props.jumpHeight * StartingJumpHeight;
		CurrentJumpDistance = props.jumpDistance * StartingJumpDistance;
		EvolutionLevel++;
	}
}
