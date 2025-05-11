using UnityEngine;
using FactionalAbilities.Handlers;

namespace AttackSystem.RangedAttackHandlers
{
    public class ReinforcedRangedAttackHandler : RangedAttackHandler
    {
        [SerializeField] private AttackAbilityHandler _abilityHandler;
    }
}