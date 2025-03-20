using UnityEngine;
using FactionalAbilities.Handlers;

namespace AttackSystem
{
    public class MushroomAttackHanlder : AttackHandler
    {
        [SerializeField] private MushroomAbilityHandler _mushroomAbilityHandler;

        protected override float Damage => _mushroomAbilityHandler.CurrentAttackDamage;
    }
}