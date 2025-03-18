using UnityEngine;
using Units;

public class RangedWatermelonAttackHandler : RangedAttackSystem
{
    [SerializeField] private WatermelonAbilityHandler _abilityHandler;

    protected override float CalculateDamage() =>
        _abilityHandler.CurrentAttackDamage;
}