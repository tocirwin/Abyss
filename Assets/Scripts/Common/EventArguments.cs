using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventArguments : MonoBehaviour {

}

public class InputEventArgs : EventArgs {
	public string pressedKey;
	public int KeyIndex;
}

public class StateEventArgs : EventArgs {
	public States newState;
}

public class EvolutionEventArgs : EventArgs {

	public EvolutionEventArgs () {}

	public EvolutionEventArgs (Moves move) {
		loggedMoved = move;
	}

	public EvolutionEventArgs (Moves move, AttackProperties attack) {
		loggedMoved = move;
		attackProperties = attack;
	}

	public EvolutionEventArgs (AttackProperties attack) {
		attackProperties = attack;
	}

	public Moves loggedMoved;
	public AttackProperties attackProperties;
}
