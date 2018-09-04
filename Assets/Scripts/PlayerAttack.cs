﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerAttack : MonoBehaviour {

	public PlayerState playerState;
	public PlayerAnimator playerAnimator;
	public GameObject fireball;
	public float fireballSpeed = 1f;
	[Range(8, 12)]
	public int hitLayer;

	private Dictionary<Moves, Func<IEnumerator>> functions = new Dictionary<Moves, Func<IEnumerator>>();

	private void Start () {
		functions.Add(Moves.StandPunch, StandPunch);
		functions.Add(Moves.StandKick, StandKick);
		functions.Add(Moves.JumpPunch, JumpPunch);
		functions.Add(Moves.JumpKick, JumpKick);
		functions.Add(Moves.CrouchPunch, CrouchPunch);
		functions.Add(Moves.CrouchKick, CrouchKick);
		functions.Add(Moves.Fireball, Fireball);
		functions.Add(Moves.DragonPunch, DragonPunch);
		functions.Add(Moves.Tatsu, Tatsu);
	}

	public void ReceiveMove (Moves move) {
		Func<IEnumerator> f = functions[move];
		StartCoroutine(f());
	}

	private IEnumerator StandPunch () {
		playerState.SetStateTimer(Moves.StandPunch, 30);
		yield return null;
	}

	private IEnumerator StandKick () {
		playerState.SetStateTimer(Moves.StandKick, 45);
		yield return null;
	}

	private IEnumerator JumpPunch () {
		playerState.SetStateTimer(Moves.JumpPunch, 35);
		yield return null;
	}

	private IEnumerator JumpKick () {
		playerState.SetStateTimer(Moves.JumpKick, 40);
		yield return null;
	}

	private IEnumerator CrouchPunch () {
		playerState.SetStateTimer(Moves.CrouchPunch, 35);
		yield return null;
	}

	private IEnumerator CrouchKick () {
		playerState.SetStateTimer(Moves.CrouchKick, 50);
		yield return null;
	}

	private IEnumerator Fireball () {
		playerState.SetStateTimer(Moves.Fireball, 35);
		yield return new WaitForSeconds(0.2f);
		GameObject projectile = Instantiate(fireball, new Vector3(transform.position.x + 100, transform.position.y - 50, -11), Quaternion.identity);
		projectile.GetComponent<Fireball>().speed.x *= fireballSpeed;
		projectile.GetComponent<HitCollider>().playerState = playerState;
		projectile.layer = hitLayer;
		if (playerState.ReturnFlipState()) {
			projectile.GetComponent<Fireball>().flipDirection();
		}
		yield return null;
	}

	private IEnumerator DragonPunch () {
		Vector3 travelRate = new Vector3(3, 10, 0);
		Vector3 fallRate = new Vector3 (0, 10, 0);
		if (playerState.ReturnFlipState()) {
			travelRate = new Vector3(-3, 10, 0);
		}
		playerState.SetStateTimer(Moves.DragonPunch, 80);
		yield return new WaitForSeconds(0.1f);
		for (int i = 0; i < 30; i++)
        {
            transform.position += travelRate;
            yield return null;
        }
        yield return new WaitForSeconds(0.1f);
        for (int i = 0; i < 30; i++)
        {
            transform.position -= fallRate;
            yield return null;
        }
		yield return null;
	}

	private IEnumerator Tatsu () {
		Vector3 travelRate = new Vector3(10, 0, 0);
		if (playerState.ReturnFlipState()) {
			travelRate = new Vector3(-10, 0, 0);
		}
		playerState.SetStateTimer(Moves.Tatsu, 90);
		for (int i = 0; i < 90; i++)
        {
            transform.position += travelRate;
            yield return null;
        }
		yield return null;
	}

}
