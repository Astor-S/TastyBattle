using UnityEngine;
using FactionalAbilities.Handlers;

namespace AttackSystem
{
    public class AbilityAttackHanlder : AttackHandler
    {
        [SerializeField] private AttackAbilityHandler _attackAbilityHandler;

        protected override float Damage => _attackAbilityHandler.CurrentAttackDamage;
    }
}