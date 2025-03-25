using System;
using UnityEngine;

[CreateAssetMenu(fileName = "AttackerUnit", menuName = "Scriptable Objects/AttackerUnit", order = 52)]
public class AttackerSetup : DamagableSetup
{
    [SerializeField] private float _attackDamage;
    [SerializeField] private float _attackSpeed;
    [SerializeField] private float _attackDistance;

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