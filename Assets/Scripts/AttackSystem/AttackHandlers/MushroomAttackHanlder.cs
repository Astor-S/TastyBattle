using FactionalAbilities.Handlers;
using UnityEngine;

namespace AttackSystem.AttackHandlers
{
    public class MushroomAttackHanlder : AbilityAttackHandler
    {
        [SerializeField] private MushroomAbilityHandler _mushroomAbilityHandler;

        public override float CalculateDamage()
        {
            return base.CalculateDamage() * _mushroomAbilityHandler.DamageBonus; ;
        }
    }
}