using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;
using System;

public class PlayerState : MonoBehaviour {

	public PlayerMovement playerMovement;
	public PlayerAttack playerAttack;
	public PlayerAnimator playerAnimator;
	private Evolutor evolutor;

	private Moves currentMove = Moves.Idle;
	
	public event EventHandler<EvolutionEventArgs> PlayerStruck;
	public event EventHandler<EvolutionEventArgs> PlayerBlocked;
	public event EventHandler<EvolutionEventArgs> PlayerAttacked;
	public event EventHandler<EvolutionEventArgs> PlayerMoved;

	public GameObject player;
	private Timer stateTimer = new Timer();

	void Start () {
		evolutor = GetComponent<Evolutor>();
		stateTimer.Elapsed += OnStateTimerElapsed;
		stateTimer.AutoReset = false;
	}

	void Update () {
		if (currentMove == Moves.Idle) {
			playerAnimator.PlayAnimation("Idle");
		}
	}

	public void SetStateTimer (Moves move, int frames) {
		SetMoveState(move);
		PlayerMoved(this, new EvolutionEventArgs(move));
		stateTimer.Interval = (frames * 1000) / 60;
		stateTimer.Start();
	}

	public void SetStateTimer (Moves move, int hitFrames, int blockFrames, AttackAngle angle) {
		if (move == Moves.Blocking) {
			SetMoveState(Moves.Blocking);
			PlayerBlocked(this, new EvolutionEventArgs(Moves.Blocking));
			stateTimer.Interval = (blockFrames * 1000) /60;
			stateTimer.Start();
		} else if (move == Moves.BeingHit) {
			SetMoveState(move);
			PlayerStruck(this, new EvolutionEventArgs(Moves.BeingHit));
			stateTimer.Interval = (hitFrames * 1000) / 60;
			stateTimer.Start();
		}
	}

	public void OnStateTimerElapsed(object sender, ElapsedEventArgs e) {
		stateTimer.Stop();
		currentMove = Moves.Idle;
	}

	public bool CheckBlocking (AttackAngle angle) {
		switch (angle)
		{
			case AttackAngle.Low:
				if (!ReturnFlipState()) {
					if (ReturnMoveState() == Moves.CrouchLeft) {
						return true;
					}
				} else if (ReturnFlipState()) {
					if (ReturnMoveState() == Moves.CrouchRight) {
						return true;
					}
				}
				break;
			case AttackAngle.Mid:
				if (!ReturnFlipState()) {
					if (ReturnMoveState() == Moves.CrouchLeft || ReturnMoveState() == Moves.WalkLeft) {
						return true;
					}
				} else if (ReturnFlipState()) {
					if (ReturnMoveState() == Moves.CrouchRight || ReturnMoveState() == Moves.WalkRight) {
						return true;
					}
				}
				break;
			case AttackAngle.High:
				if (!ReturnFlipState()) {
					if (ReturnMoveState() == Moves.WalkLeft) {
						return true;
					}
				} else if (ReturnFlipState()) {
					if (ReturnMoveState() == Moves.WalkRight) {
						return true;
					}
				}
				break;
		}
		return false;
	}

	public void InvokeMove (Moves move) {
		if (move != Moves.None) {
			foreach (Moves m in Enums.MovementMoves) {
				if (m == move) {
					playerMovement.ReceiveMove(move);
				}
			}
			foreach (Moves m in Enums.AttackMoves) {
				if (m == move) {
					playerAttack.ReceiveMove(move);
				}
			}
		}
	}

	public Moves ReturnMoveState () {
		return currentMove;
	}

	public bool ReturnFlipState () {
		return GetComponent<SpriteRenderer>().flipX;
	}

	public void LogAttackEvent (AttackProperties attack) {
		PlayerAttacked(this, new EvolutionEventArgs(attack));
	}

	private void SetMoveState (Moves move) {
		if (move != currentMove) {
			currentMove = move;
			playerAnimator.PlayAnimation(move.ToString());
		}
	}
}
