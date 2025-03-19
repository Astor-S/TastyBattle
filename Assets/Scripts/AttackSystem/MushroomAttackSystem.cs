using UnityEngine;
using Units;

public class MushroomAttackSystem : AttackHandler
{
    [SerializeField] private MushroomAbilityHandler _mushroomAbilityHandler;

    protected override float Damage => _mushroomAbilityHandler.CurrentAttackDamage;
}