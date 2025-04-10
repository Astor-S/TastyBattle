using System;
using UnityEngine;

[CreateAssetMenu(fileName = "AttackerUnit", menuName = "Scriptable Objects/AttackerUnit", order = 52)]
public class AttackerSetup : DamagableSetup
{
    public const int MinAttackSpeed = 1;
    public const int MaxAttackSpeed = 10;
    private const int MinAttackDamage = 1;
    private const int MaxAttackDamage = 25;
    public const int MinAttackRange = 2;
    private const int MaxAttackRange = 7;

    [SerializeField, Range(MinAttackDamage, MaxAttackDamage)] private float _attackDamage;
    [SerializeField, Range(MinAttackRange, MaxAttackRange)] private float _attackDistance;
    [SerializeField, Range(MinAttackSpeed, MaxAttackSpeed)] private float _attackSpeed;

    public float AttackDamage { get; private set; }
    public float AttackSpeed { get; private set; }
    public float AttackDistance { get; private set; }

    public void IncreaseDamage(float damageBoostPortion)
    {
        if (damageBoostPortion < 0 || damageBoostPortion > 1)
            throw new ArgumentOutOfRangeException("Damage boost portion is a number between 0 and 1.");

        AttackDamage += AttackDamage * damageBoostPortion;
    }

    protected override void Initialize()
    {
        base.Initialize();

        AttackDamage = _attackDamage;
        AttackSpeed = _attackSpeed;
        AttackDistance = _attackDistance;
    }
}