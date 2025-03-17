using UnityEngine;
using Units;

public class MushroomAttackSystem : AttackSystem
{
    [SerializeField] private MushroomUnit _mushroomUnit;

    protected override float Damage => _mushroomUnit.CurrentAttackDamage;
}