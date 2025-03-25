using UnityEngine;
using FactionalAbilities.Handlers;

namespace AttackSystem
{
    public class ReinforcedRangedAttackHandler : RangedAttackHandler
    {
        [SerializeField] private AttackAbilityHandler _abilityHandler;

        protected override float CalculateDamage() =>
            _abilityHandler.CurrentAttackDamage;
    }
}