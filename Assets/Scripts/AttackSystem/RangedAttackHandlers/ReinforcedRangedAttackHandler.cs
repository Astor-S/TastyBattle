using UnityEngine;
using FactionalAbilities.Handlers;

namespace AttackSystem.RangedAttackHandlers
{
    public class ReinforcedRangedAttackHandler : RangedAttackHandler
    {
        [SerializeField] private AbilityHandler _abilityHandler;

        public override float CalculateDamage() =>
            base.CalculateDamage() * _abilityHandler.CurrentDamageBonus;
    }
}