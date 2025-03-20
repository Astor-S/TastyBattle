using UnityEngine;
using Units;

public class MushroomAttackSystem : AttackHandler
{
    [SerializeField] private MushroomUnit _mushroomUnit;

    protected override float Damage => _mushroomUnit.CurrentAttackDamage;
}