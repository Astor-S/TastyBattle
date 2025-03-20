using UnityEngine;
using Units;

public class WatermelonAttackHandler : AttackHandler
{
    [SerializeField] private WatermelonAbilityHandler _abilityHandler;

    public WatermelonAttackHandler(DetectionSystem detectionSystem, Health health) : base(detectionSystem, health)
    {
    }

    protected override float CalculateDamage() =>
       _abilityHandler.CurrentAttackDamage;
}