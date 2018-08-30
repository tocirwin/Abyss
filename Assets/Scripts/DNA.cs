using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DNA : MonoBehaviour {

	public List<Image> slots = new List<Image>();
	private int sequenceCount = 0;

	void Start () {
		Reset();
	}

	public void UpdateDNA (Evolutor.Sequences seq) {
		switch (seq) {
			case Evolutor.Sequences.Offensive:
				slots[sequenceCount].color = Color.red;
				goto default;
			case Evolutor.Sequences.Defensive:
				slots[sequenceCount].color = Color.blue;
				goto default;
			case Evolutor.Sequences.Technical:
				slots[sequenceCount].color = Color.yellow;
				goto default;
			default:
				sequenceCount++;
			break;
		}
	}

	public void Reset () {
		foreach (Image x in slots) {
			x.color = Color.white;
		}
		sequenceCount = 0;
	}
}
