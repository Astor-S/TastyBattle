using UnityEngine;
using FactionalAbilities.Handlers;

namespace AttackSystem.AttackHandlers
{
    public class AbilityAttackHandler : AttackHandler
    {
        [SerializeField] private AttackAbilityHandler _attackAbilityHandler;

        public override float CalculateDamage() =>
            base.CalculateDamage() * _attackAbilityHandler.CurrentDamageBonus;
    }
}