using System;
using UnityEngine;

[CreateAssetMenu(fileName = "AttackerUnit", menuName = "Scriptable Objects/AttackerUnit", order = 52)]
public class AttackerSetup : DamagableSetup
{
    [SerializeField] private float _attackDamage;
    [SerializeField] private float _attackSpeed;

    public float AttackSpeed => _attackSpeed;
    public float AttackDamage => _attackDamage;

    public void IncreaseDamage(float damageBoostPortion)
    {
        if (damageBoostPortion < 0 || damageBoostPortion > 1)
            throw new ArgumentOutOfRangeException("Damage boost portion is a number between 0 and 1.");

        _attackDamage += _attackDamage * damageBoostPortion;
    }
}