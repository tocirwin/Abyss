using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackProperties : object {

	public int hitStun;
	public int blockStun;
	public int damage;
	public int push;
	public AttackAngle angle;

	public AttackProperties() {}

	public AttackProperties(int Hitstun, int Blockstun, int Damage, int Push, AttackAngle Angle) : this() {
		hitStun = Hitstun;
		blockStun = Blockstun;
		damage = Damage;
		push = Push;
		angle = Angle;
	}

}
