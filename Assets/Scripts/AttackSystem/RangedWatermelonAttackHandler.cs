using UnityEngine;
using Units;

public class RangedWatermelonAttackHandler : RangedAttackHandler
{
    [SerializeField] private WatermelonAbilityHandler _abilityHandler;

    protected override float CalculateDamage() =>
        _abilityHandler.CurrentAttackDamage;
}