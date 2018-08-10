using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HurtCollider : MonoBehaviour {

	private PlayerHealth playerHealth;
	private PlayerState playerState;
	private ParticleSystem particle;

	public void TakeDamage () {
		playerHealth.TakeDamage(20);
	}

	public void ReceiveAttack (HitCollider hitCollider, AttackProperties attack) {
		bool blocked = false;
		Moves nextMove = Moves.None;
		switch (playerState.CheckBlocking(attack.angle))
		{
			case true:
				nextMove = Moves.Blocking;
				blocked = true;
				break;
			case false:
				nextMove = Moves.BeingHit;
				blocked = false;
				playerHealth.TakeDamage(attack.damage);
				particle.Play();
				break;
		}
		playerState.SetStateTimer(nextMove, attack.hitStun, attack.blockStun, attack.angle);
		hitCollider.ReceiveAttackFeedback(attack, blocked);
	}

	// Use this for initialization
	void Start () {
		playerHealth = GetComponentInParent<PlayerHealth>();
		playerState = GetComponentInParent<PlayerState>();
		particle = GetComponentInChildren<ParticleSystem>();
	}
}
