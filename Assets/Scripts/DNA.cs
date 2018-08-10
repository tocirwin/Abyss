using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DNA : MonoBehaviour {

	//comment for git test

	public GameObject player;
	public List<Image> slots = new List<Image>();
	public enum Sequences {Offensive, Defensive, Technical};
	private int sequenceCount = 0;

	void Start () {
		Evolve();
	}

	public void AddSequence (Sequences seq) {
		switch (seq) {
			case Sequences.Offensive:
				slots[sequenceCount].color = Color.red;
				goto default;
			case Sequences.Defensive:
				slots[sequenceCount].color = Color.blue;
				goto default;
			case Sequences.Technical:
				slots[sequenceCount].color = Color.yellow;
				goto default;
			default:
				sequenceCount++;
				if (sequenceCount > 7) {
					Evolve();
				}
			break;
		}
	}

	private void Evolve () {
		int totalRed = 0;
		int totalBlue = 0;
		int totalYellow = 0;

		foreach (Image x in slots) {
			if (x.color == Color.red) {
				totalRed++;
			} else if (x.color == Color.blue) {
				totalBlue++;
			} else if (x.color == Color.yellow) {
				totalYellow++;
			}
		}
		
		//DNA should simply send a string/enum to PlayerStats, which itself can parse what level the character is and access dictionary from there
		if (totalRed > totalBlue && totalRed > totalYellow) {
			player.GetComponent<PlayerStats>().EvolveUpdate(Characters.CharacterStatsDictionary[CharNames.O]);
		}

		if (totalBlue > totalRed && totalBlue > totalYellow) {
			player.GetComponent<PlayerStats>().EvolveUpdate(Characters.CharacterStatsDictionary[CharNames.D]);
		}

		if (totalYellow > totalRed && totalYellow > totalBlue) {
			player.GetComponent<PlayerStats>().EvolveUpdate(Characters.CharacterStatsDictionary[CharNames.T]);
		}

		foreach (Image x in slots) {
			x.color = Color.white;
		}
		sequenceCount = 0;
	}
}
