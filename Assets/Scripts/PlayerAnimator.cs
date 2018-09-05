using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerAnimator : MonoBehaviour {

	private Animator animator;
	private RuntimeAnimatorController ac;

	public void Awake () {
		animator = GetComponent<Animator>();
		ac = animator.runtimeAnimatorController;
	}

	public void PlayAnimation (string anim) {
		animator.Play(anim);
	}

	public float ReturnAnimationFrames (Moves move) {
		for (int i = 0; i < ac.animationClips.Length; i++) {
			if (ac.animationClips[i].name == move.ToString()) {
				Debug.Log (move.ToString() + " : " + ac.animationClips[i].length * 60);
				return ac.animationClips[i].length * 60;
			}
		}
		return 0;
	}

}
