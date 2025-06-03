using UnityEngine;
using FactionalAbilities.Handlers;

namespace AttackSystem.AttackHandlers
{
    public class AttackerWithAbility : AttackHandler
    {
        [SerializeField] private AbilityHandler _abilityHandler;

        public override float CalculateDamage() =>
            base.CalculateDamage() * _abilityHandler.CurrentDamageBonus;
    }
}