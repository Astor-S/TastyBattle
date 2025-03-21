using UnityEngine;
using FactionalAbilities.Handlers;

namespace AttackSystem
{
    public class WatermelonAttackHandler : AttackHandler
    {
        [SerializeField] private WatermelonAbilityHandler _watermelonAbilityHandler;

        protected override float Damage => _watermelonAbilityHandler.CurrentAttackDamage;
    }
}