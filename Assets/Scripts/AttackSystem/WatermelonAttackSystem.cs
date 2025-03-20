using UnityEngine;
using Units;

public class WatermelonAttackSystem : AttackHandler
{
    [SerializeField] private WatermelonUnit _watermelonUnit;

    protected override float Damage => _watermelonUnit.CurrentAttackDamage;
}