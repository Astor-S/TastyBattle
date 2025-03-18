using UnityEngine;
using Units;

public class WatermelonAttackHandler : AttackHandler
{
    [SerializeField] private WatermelonAbilityHandler _abilityHandler;

    protected override float CalculateDamage() =>
       _abilityHandler.CurrentAttackDamage;
}