using UnityEngine;
using Units;

public class MushroomAttackSystem : AttackHandler
{
    [SerializeField] private MushroomAbilityHandler _mushroomUnit;

    protected override float Damage => _mushroomUnit.CurrentAttackDamage;
}