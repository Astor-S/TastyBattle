using UnityEngine;
using FactionalAbilities.Handlers;

namespace AttackSystem.AttackHandlers
{
    public class AbilityAttackHandler : AttackHandler
    {
        [SerializeField] private AttackAbilityHandler _attackAbilityHandler;

        protected override float Damage => _attackAbilityHandler.CurrentAttackDamage;
    }
}