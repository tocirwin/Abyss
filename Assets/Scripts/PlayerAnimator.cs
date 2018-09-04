using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerAnimator : MonoBehaviour {

	private Animator animator;
	public ParticleSystem particle;

	public void Awake () {
		animator = GetComponent<Animator>();
	}

	public void PlayAnimation (string anim) {
		if (anim != "Blocking" || anim != "BeingHit") {
			
		}
		animator.Play(anim);
	}

}
