using Units;
using UnityEngine;

public class MushroomAttackSystem : AttackSystem
{
    [SerializeField] private MushroomUnit _mushroomUnit;

    protected override float Damage => _mushroomUnit.CurrentAttackDamage;
}