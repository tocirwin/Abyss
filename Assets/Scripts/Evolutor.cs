using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Evolutor : MonoBehaviour {

	public ParticleSystem particle;
	public DNA dna;
	public enum Sequences {Offensive, Defensive, Technical};
	private List<Sequences> currentSequences = new List<Sequences>();
	private int sequenceCount;

	private PlayerState playerState;
	private AttackAngle lastAttackAngle;
	private PlayerHealth playerHealth;
	private PlayerMovement playerMovement;
	private int damageInFramesCounter;
	private Moves[] normalMoves = new Moves[] 
		{Moves.CrouchPunch, Moves.CrouchKick, Moves.StandPunch, 
		Moves.StandKick, Moves.JumpPunch, Moves.JumpKick};

	#region Event Counters
	
	private int _framesHeldBack;
	private int framesHeldBack
	{
		get {return _framesHeldBack;}
		set {
			_framesHeldBack = value;
			if (_framesHeldBack >= 1200) {
				Defensive();
				framesHeldBack = 0;
			}
		}
	}

	private int _framesHeldForward;
	private int framesHeldForward
	{
		get {return _framesHeldForward;}
		set {
			_framesHeldForward = value;
			if (_framesHeldForward >= 1200) {
				Offensive();
				framesHeldForward = 0;
			}
		}
	}

	private int _jumpCount;
	private int jumpCount
	{
		get {return _jumpCount;}
		set {
			_jumpCount = value;
			if (_jumpCount >= 2) {
				Technical();
				jumpCount = 0;
			}
		}
	}

	private int _attacksWithoutBeingHit;
	private int attacksWithoutBeingHit
	{
		get {return _attacksWithoutBeingHit;}
		set {
			_attacksWithoutBeingHit = value;
			if (_attacksWithoutBeingHit >= 4) {
				Offensive();
				attacksWithoutBeingHit = 0;
			}
		}
	}

	private int _framesWithoutBeingHit;
	private int framesWithoutBeingHit
	{
		get {return _framesWithoutBeingHit;}
		set {
			_framesWithoutBeingHit = value;
			if (_framesWithoutBeingHit >= 1800) {
				Defensive();
				framesWithoutBeingHit = 0;
			}
		}
	}

	private int _fireballsCount;
	private int fireballsCount
	{
		get {return _fireballsCount;}
		set {
			_fireballsCount = value;
			if (_fireballsCount >= 10) {
				Technical();
				fireballsCount = 0;
			}
		}
	}

	private int _variedAttacksCount;
	private int variedAttacksCount
	{
		get {return _variedAttacksCount;}
		set {
			_variedAttacksCount = value;
			if (_variedAttacksCount >= 3) {
				Offensive();
				variedAttacksCount = 0;
			}
		}
	}

	private int _damageInFrames;
	private int damageInFrames
	{
		get {return _damageInFrames;}
		set {
			_damageInFrames = value;
			if (_damageInFrames >= 50) {
				Offensive();
				damageInFrames = 0;
			}
		}
	}

	private int _framesWithoutBlocking;
	private int framesWithoutBlocking
	{
		get {return _framesWithoutBlocking;}
		set {
			_framesWithoutBlocking = value;
			if (_framesWithoutBlocking >= 1800) {
				Defensive();
				framesWithoutBlocking = 0;
			}
		}
	}
	
	private int _dragonPunchCount;
	private int dragonPunchCount
	{
		get {return _dragonPunchCount;}
		set {
			_dragonPunchCount = value;
			if (_dragonPunchCount >= 5) {
				Technical();
				dragonPunchCount = 0;
			}
		}
	}

	private int _tatsuCount;
	private int tatsuCount
	{
		get {return _tatsuCount;}
		set {
			_tatsuCount = value;
			if (_tatsuCount >= 5) {
				Technical();
				tatsuCount = 0;
			}
		}
	}

	private int _attacksFromAirCount;
	private int attacksFromAirCount
	{
		get {return _attacksFromAirCount;}
		set {
			_attacksFromAirCount = value;
			if (_attacksFromAirCount >= 3) {
				Technical();
				attacksFromAirCount = 0;
			}
		}
	}

	private int _blockCount;
	private int BlockCount
	{
		get {return _blockCount;}
		set {
			_blockCount = value;
			if (_blockCount >= 5) {
				Defensive();
				BlockCount = 0;
			}
		}
	}
	#endregion

	void Start () {
		playerState = GetComponent<PlayerState>();
		playerHealth = GetComponent<PlayerHealth>();
		playerMovement = GetComponent<PlayerMovement>();
		playerState.PlayerStruck += OnPlayerStruck;
		playerState.PlayerAttacked += OnPlayerAttacked;
		playerState.PlayerBlocked += OnPlayerBlocked;
		playerState.PlayerMoved += OnPlayerMoved;
	}

	void Update () {
		framesWithoutBeingHit++;
		framesWithoutBlocking++;
		damageInFramesCounter++;
		if (damageInFramesCounter >= 120) {
			damageInFrames = 0;
			damageInFramesCounter = 0;
		}
	}

	#region On Events
	public void OnPlayerStruck (object sender, EvolutionEventArgs e) {
		attacksWithoutBeingHit = 0;
		framesWithoutBeingHit = 0;
	}

	public void OnPlayerBlocked (object sender, EvolutionEventArgs e) {
		BlockCount++;
		framesWithoutBlocking = 0;
	}

	public void OnPlayerMoved (object sender, EvolutionEventArgs e) {
		switch (e.loggedMoved)
		{
			case Moves.WalkLeft:
				if (!playerState.ReturnFlipState()) framesHeldBack++;
				else if (playerState.ReturnFlipState()) framesHeldForward++;
				break;
			case Moves.WalkRight:
				if (!playerState.ReturnFlipState()) framesHeldForward++;
				else if (playerState.ReturnFlipState()) framesHeldBack++;
				break;
			case Moves.JumpNeutral:
				jumpCount++;
				break;
			case Moves.JumpLeft:
				jumpCount++;
				break;
			case Moves.JumpRight:
				jumpCount++;
				break;
			case Moves.Tatsu:
				tatsuCount++;
				break;
			case Moves.DragonPunch:
				dragonPunchCount++;
				break;
			case Moves.Fireball:
				fireballsCount++;
				break;
			default:
				break;
		}
	}

	public void OnPlayerAttacked (object sender, EvolutionEventArgs e) {
		attacksWithoutBeingHit++;
		damageInFrames += e.attackProperties.damage;
		if (e.attackProperties.angle == AttackAngle.High) {
			attacksFromAirCount++;
		}
		switch (lastAttackAngle)
		{
			case AttackAngle.Low:
				if (e.attackProperties.angle == AttackAngle.High) variedAttacksCount++;
				else variedAttacksCount = 0;
				break;
			case AttackAngle.High:
				if (e.attackProperties.angle == AttackAngle.Low) variedAttacksCount++;
				else variedAttacksCount = 0;
				break;
			case AttackAngle.Mid:
				variedAttacksCount = 0;
				break;
			default:
				break;
		}
		lastAttackAngle = e.attackProperties.angle;
	}
	#endregion

	#region Sequence Effects

	private void Offensive () {
		RecordSequence(Sequences.Offensive);
		var main = particle.main;
		main.startColor = Color.red;
		particle.Play();
	}

	private void Defensive () {
		RecordSequence(Sequences.Defensive);
		var main = particle.main;
		main.startColor = Color.green;
		particle.Play();
	}

	private void Technical () {
		RecordSequence(Sequences.Technical);
		var main = particle.main;
		main.startColor = Color.yellow;
		particle.Play();
	}

	private void RecordSequence (Sequences sequence) {
		dna.UpdateDNA(sequence);
		currentSequences.Add(sequence);
		sequenceCount++;
		if (sequenceCount > 7) {
			Evolve();
			dna.Reset();
			sequenceCount = 0;
		}
	}

	private void Evolve() {
		Sequences selection = currentSequences[UnityEngine.Random.Range(0, 7)];
		CharNames nextChar = CharNames.N;
		switch (selection) {
			case Sequences.Offensive:
				nextChar = CharNames.O;
			break;
			case Sequences.Defensive:
				nextChar = CharNames.D;
			break;
			case Sequences.Technical:
				nextChar = CharNames.T;
			break;
		}
		GetComponent<PlayerStats>().EvolveUpdate (Characters.CharacterStatsDictionary[nextChar]);
	}

	#endregion
}
