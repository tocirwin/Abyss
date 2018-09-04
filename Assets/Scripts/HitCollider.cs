using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCollider : MonoBehaviour {

	[Range(1, 2)]
	public int player;

	public CharNames thisChar;
	public Moves thisMove;
	public PlayerState playerState;

	//
	//Change to "player" interface that can be used for fireballs and hit/hurtboxes, instead of layers.
	//
	public void OnTriggerEnter2D (Collider2D collider) {
		switch (gameObject.layer)
		{
			case 9:
			if (collider.gameObject.layer == 10) {
				if (collider.gameObject.GetComponent<HurtCollider>()) {
					collider.gameObject.GetComponent<HurtCollider>().ReceiveAttack(this, Characters.CharacterMovesDictionary[thisChar][thisMove]);
					if (thisMove == Moves.Fireball) {
						gameObject.GetComponent<Fireball>().Explode();
					}
				}
			}
			break;
			case 11:
			if (collider.gameObject.layer == 8) {
				if (collider.gameObject.GetComponent<HurtCollider>()) {
					collider.gameObject.GetComponent<HurtCollider>().ReceiveAttack(this, Characters.CharacterMovesDictionary[thisChar][thisMove]);
					if (thisMove == Moves.Fireball) {
						gameObject.GetComponent<Fireball>().Explode();
					}
				}
			}
			break;
		}
	}

	public void ReceiveAttackFeedback (AttackProperties attack, bool blocked) {
		if (!blocked) {
			playerState.LogAttackEvent(attack);
		}
	}

}
