using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerAnimator : MonoBehaviour {

	private Animator animator;

	public void Awake () {
		animator = GetComponent<Animator>();
	}

	public void PlayAnimation (string anim) {
		animator.Play(anim);
	}

}
