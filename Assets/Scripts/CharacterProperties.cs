using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterProperties : object {

	public float health;
	public float forwardSpeed;
	public float backwardSpeed;
	public float jumpDuration;
	public float jumpHeight;
	public float jumpDistance;

	public CharacterProperties () {}

	public CharacterProperties (float Health, float ForwardSpeed, float BackwardSpeed, float JumpDuration, float JumpHeight, float JumpDistance) : this() {
		health = Health;
		forwardSpeed = ForwardSpeed;
		backwardSpeed = BackwardSpeed;
		jumpDuration = JumpDuration;
		jumpHeight = JumpHeight;
		jumpDistance = JumpDistance;
	}

}
