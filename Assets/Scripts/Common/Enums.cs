using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Enums : object {

	public static Dictionary<Moves, Moves[]> AllowedMoves = new Dictionary<Moves, Moves[]>()
    {
        {Moves.Idle, new Moves[]{Moves.WalkLeft}},
        {Moves.WalkRight, new Moves[]{Moves.All}},
        {Moves.WalkLeft, new Moves[]{Moves.All}},
        {Moves.JumpNeutral, new Moves[]{Moves.JumpPunch, Moves.JumpKick}},
        {Moves.JumpRight, new Moves[]{Moves.JumpPunch, Moves.JumpKick}},
        {Moves.JumpLeft, new Moves[]{Moves.JumpPunch, Moves.JumpKick}},
        {Moves.Crouch, new Moves[]{Moves.CrouchPunch, Moves.CrouchKick, Moves.CrouchLeft}},
        {Moves.CrouchLeft, new Moves[]{Moves.CrouchPunch, Moves.CrouchKick, Moves.Crouch}},
        {Moves.CrouchRight, new Moves[]{Moves.CrouchPunch, Moves.CrouchKick, Moves.Crouch}},
        {Moves.StandPunch, new Moves[]{Moves.Fireball, Moves.DragonPunch}},
        {Moves.StandKick, new Moves[]{Moves.Fireball, Moves.Tatsu}},
        {Moves.JumpPunch, new Moves[]{Moves.None}},
        {Moves.JumpKick, new Moves[]{Moves.None}},
        {Moves.CrouchPunch, new Moves[]{Moves.Fireball, Moves.DragonPunch}},
        {Moves.CrouchKick, new Moves[]{Moves.Fireball, Moves.Tatsu}},
        {Moves.Fireball, new Moves[]{Moves.None}},
        {Moves.Throw, new Moves[]{Moves.None}},
        {Moves.Tatsu, new Moves[]{Moves.None}},
        {Moves.DragonPunch, new Moves[]{Moves.None}}
    };

    public static Dictionary<string, Dictionary<Moves, Moves>> KeysAndMovesDict = new Dictionary<string, Dictionary<Moves, Moves>>()
    {
        {"Left", new Dictionary<Moves, Moves>{
            {Moves.WalkLeft, Moves.WalkLeft}, {Moves.WalkRight, Moves.WalkLeft}, {Moves.Crouch, Moves.CrouchLeft},
            {Moves.CrouchLeft, Moves.CrouchLeft}, {Moves.CrouchRight, Moves.CrouchLeft}, {Moves.Idle, Moves.WalkLeft}}},
        {"Right", new Dictionary<Moves, Moves>{
            {Moves.WalkLeft, Moves.WalkRight}, {Moves.WalkRight, Moves.WalkRight}, {Moves.Crouch, Moves.CrouchRight},
            {Moves.CrouchLeft, Moves.CrouchRight}, {Moves.CrouchRight, Moves.CrouchRight}, {Moves.Idle, Moves.WalkRight}}},
        {"Up", new Dictionary<Moves, Moves>{
            {Moves.WalkLeft, Moves.JumpNeutral}, {Moves.WalkRight, Moves.JumpNeutral}, {Moves.Idle, Moves.JumpNeutral},
            }},
        {"Down", new Dictionary<Moves, Moves>{
            {Moves.WalkLeft, Moves.Crouch}, {Moves.WalkRight, Moves.Crouch}, {Moves.Idle, Moves.Crouch},
            {Moves.Crouch, Moves.Crouch}, {Moves.CrouchLeft, Moves.CrouchLeft}, {Moves.CrouchRight, Moves.CrouchRight},
            }},
        {"Punch", new Dictionary<Moves, Moves>{
            {Moves.WalkLeft, Moves.StandPunch}, {Moves.WalkRight, Moves.StandPunch}, {Moves.Idle, Moves.StandPunch},
            {Moves.Crouch, Moves.CrouchPunch}, {Moves.CrouchLeft, Moves.CrouchPunch}, {Moves.CrouchRight, Moves.CrouchPunch}, 
            {Moves.JumpNeutral, Moves.JumpPunch}, {Moves.JumpLeft, Moves.JumpPunch}, {Moves.JumpRight, Moves.JumpPunch}}},
        {"Kick", new Dictionary<Moves, Moves>{
            {Moves.WalkLeft, Moves.StandKick}, {Moves.WalkRight, Moves.StandKick}, {Moves.Idle, Moves.StandKick},
            {Moves.Crouch, Moves.CrouchKick}, {Moves.CrouchLeft, Moves.CrouchKick}, {Moves.CrouchRight, Moves.CrouchKick}, 
            {Moves.JumpNeutral, Moves.JumpKick}, {Moves.JumpLeft, Moves.JumpKick}, {Moves.JumpRight, Moves.JumpKick}}}
    };

    public static Dictionary<Moves, Dictionary<Moves, Moves>> KeysAndSpecialsDict = new Dictionary<Moves, Dictionary<Moves, Moves>>()
    {
        {Moves.Fireball, new Dictionary<Moves, Moves>{
            {Moves.WalkLeft, Moves.Fireball}, {Moves.WalkRight, Moves.Fireball}, {Moves.Crouch, Moves.Fireball}, 
            {Moves.CrouchLeft, Moves.Fireball}, {Moves.CrouchRight, Moves.Fireball}, {Moves.Idle, Moves.Fireball},
            {Moves.StandPunch, Moves.Fireball}, {Moves.CrouchPunch, Moves.Fireball}}},
        {Moves.DragonPunch, new Dictionary<Moves, Moves>{
            {Moves.WalkLeft, Moves.DragonPunch}, {Moves.WalkRight, Moves.DragonPunch}, {Moves.Crouch, Moves.DragonPunch}, 
            {Moves.CrouchLeft, Moves.DragonPunch}, {Moves.CrouchRight, Moves.DragonPunch}, {Moves.Idle, Moves.DragonPunch},
            {Moves.StandPunch, Moves.DragonPunch}, {Moves.CrouchPunch, Moves.DragonPunch}}},
        {Moves.Tatsu, new Dictionary<Moves, Moves>{
            {Moves.WalkLeft, Moves.Tatsu}, {Moves.WalkRight, Moves.Tatsu}, {Moves.Crouch, Moves.Tatsu}, 
            {Moves.CrouchLeft, Moves.Tatsu}, {Moves.CrouchRight, Moves.Tatsu}, {Moves.Idle, Moves.Tatsu},
            {Moves.StandKick, Moves.Tatsu}, {Moves.CrouchKick, Moves.Tatsu}}}
    };

    //Hitstun, blockstun, damage, push, angle
    public static Dictionary<Moves, AttackProperties> MovesAttackProperties = new Dictionary<Moves, AttackProperties>()
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
    };

    public static Moves[] MovementMoves =
    {
        Moves.WalkRight, Moves.WalkLeft, Moves.JumpNeutral, 
        Moves.JumpRight, Moves.JumpLeft, Moves.Crouch, Moves.CrouchLeft, Moves.CrouchRight
    };

    public static Moves[] AttackMoves =
    {
        Moves.StandPunch, Moves.StandKick, Moves.JumpPunch, 
        Moves.JumpKick, Moves.CrouchPunch, Moves.CrouchKick, 
        Moves.Fireball, Moves.Throw, Moves.Tatsu, Moves.DragonPunch
    };
}

public static class MoveKeyStates : object {

public static Moves MoveStateOutcome (string key, Moves current) {
    Dictionary<Moves, Moves> possibleMoves = Enums.KeysAndMovesDict[key];
    if (possibleMoves.ContainsKey(current)) {
        return possibleMoves[current];
    } else return Moves.None;
}

public static Moves MoveStateSpecialOutcome (Moves target, Moves current) {
    Dictionary<Moves, Moves> possibleMoves = Enums.KeysAndSpecialsDict[target];
    if (possibleMoves.ContainsKey(current)) {
        return possibleMoves[current];
    } else return Moves.None;
}

}

public enum States {Idle, Attacking, Jumping, Moving, Crouching, BeingHit, Blocking};

public enum Moves : byte
{
    All,
    None,
    Idle,
    Blocking, BeingHit,
    WalkRight, WalkLeft, JumpNeutral, JumpRight, JumpLeft, Crouch, CrouchLeft, CrouchRight,
    StandPunch, StandKick, JumpPunch, JumpKick, CrouchPunch, CrouchKick,
    Fireball, Throw, Tatsu, DragonPunch
};

public enum AttackAngle : byte
{
    Low, Mid, High
};

public enum CharNames : byte
{
    N, O, D, T, OO, OD, OT, DD, DO, DT, TT, TO, TD
};
