using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Characters : object {

	public static Dictionary<CharNames, Dictionary<Moves, AttackProperties>> CharacterMovesDictionary = new Dictionary<CharNames, Dictionary<Moves, AttackProperties>>
	{
		{CharNames.N, new Dictionary<Moves, AttackProperties>()
    	{
			{Moves.StandPunch, new AttackProperties(20, 18, 10, 0, AttackAngle.Mid)},
			{Moves.StandKick, new AttackProperties(35, 32, 15, 0, AttackAngle.Mid)},
			{Moves.CrouchPunch, new AttackProperties(25, 22, 10, 0, AttackAngle.Low)},
			{Moves.CrouchKick, new AttackProperties(30, 20, 20, 0, AttackAngle.Low)},
			{Moves.JumpPunch, new AttackProperties(30, 30, 15, 0, AttackAngle.High)},
			{Moves.JumpKick, new AttackProperties(45, 40, 20, 0, AttackAngle.High)},
			{Moves.Fireball, new AttackProperties(20, 15, 15, 0, AttackAngle.Mid)},
			{Moves.DragonPunch, new AttackProperties(60, 30, 30, 0, AttackAngle.Mid)},
			{Moves.Tatsu, new AttackProperties(30, 20, 20, 0, AttackAngle.Mid)}
    	}},
		{CharNames.O, new Dictionary<Moves, AttackProperties>()
		{
			{Moves.StandPunch, new AttackProperties(20, 18, 10, 0, AttackAngle.Mid)},
			{Moves.StandKick, new AttackProperties(35, 32, 15, 0, AttackAngle.Mid)},
			{Moves.CrouchPunch, new AttackProperties(25, 22, 10, 0, AttackAngle.Low)},
			{Moves.CrouchKick, new AttackProperties(30, 20, 20, 0, AttackAngle.Low)},
			{Moves.JumpPunch, new AttackProperties(30, 30, 15, 0, AttackAngle.High)},
			{Moves.JumpKick, new AttackProperties(45, 40, 20, 0, AttackAngle.High)},
			{Moves.Fireball, new AttackProperties(20, 15, 15, 0, AttackAngle.Mid)},
			{Moves.DragonPunch, new AttackProperties(60, 30, 30, 0, AttackAngle.Mid)},
			{Moves.Tatsu, new AttackProperties(30, 20, 20, 0, AttackAngle.Mid)}
		}},
		{CharNames.D, new Dictionary<Moves, AttackProperties>()
		{
			{Moves.StandPunch, new AttackProperties(20, 18, 10, 0, AttackAngle.Mid)},
			{Moves.StandKick, new AttackProperties(35, 32, 15, 0, AttackAngle.Mid)},
			{Moves.CrouchPunch, new AttackProperties(25, 22, 10, 0, AttackAngle.Low)},
			{Moves.CrouchKick, new AttackProperties(30, 20, 20, 0, AttackAngle.Low)},
			{Moves.JumpPunch, new AttackProperties(30, 30, 15, 0, AttackAngle.High)},
			{Moves.JumpKick, new AttackProperties(45, 40, 20, 0, AttackAngle.High)},
			{Moves.Fireball, new AttackProperties(20, 15, 15, 0, AttackAngle.Mid)},
			{Moves.DragonPunch, new AttackProperties(60, 30, 30, 0, AttackAngle.Mid)},
			{Moves.Tatsu, new AttackProperties(30, 20, 20, 0, AttackAngle.Mid)}
		}},
		{CharNames.T, new Dictionary<Moves, AttackProperties>()
		{
			{Moves.StandPunch, new AttackProperties(20, 18, 10, 0, AttackAngle.Mid)},
			{Moves.StandKick, new AttackProperties(35, 32, 15, 0, AttackAngle.Mid)},
			{Moves.CrouchPunch, new AttackProperties(25, 22, 10, 0, AttackAngle.Low)},
			{Moves.CrouchKick, new AttackProperties(30, 20, 20, 0, AttackAngle.Low)},
			{Moves.JumpPunch, new AttackProperties(30, 30, 15, 0, AttackAngle.High)},
			{Moves.JumpKick, new AttackProperties(45, 40, 20, 0, AttackAngle.High)},
			{Moves.Fireball, new AttackProperties(20, 15, 15, 0, AttackAngle.Mid)},
			{Moves.DragonPunch, new AttackProperties(60, 30, 30, 0, AttackAngle.Mid)},
			{Moves.Tatsu, new AttackProperties(30, 20, 20, 0, AttackAngle.Mid)}
		}}};

	public static Dictionary<CharNames, CharacterProperties> CharacterStatsDictionary = new Dictionary<CharNames, CharacterProperties>()
	{
		{CharNames.N, new CharacterProperties(1, 1, 1, 1, 1, 1)},
		{CharNames.O, new CharacterProperties(1.25f, 1.25f, 1.75f, 1, 1, 1)},
		{CharNames.D, new CharacterProperties(2.50f, 0.75f, 0.75f, 1.50f, 1.50f, 1)},
		{CharNames.T, new CharacterProperties(1.25f, 1.75f, 1.25f, 0.75f, 1.25f, 1.25f)}
	};

}
