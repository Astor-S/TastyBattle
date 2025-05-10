using AttackSystem.AttackHandlers;
using UnityEngine;

namespace FactionalAbilities.Handlers
{
    public class AttackAbilityHandler : MonoBehaviour
    {
        [SerializeField] private AttackHandler _attackHandler;

        private float _currentAttackDamage;

        public float CurrentAttackDamage => _currentAttackDamage;

        protected float GetBaseAttackDamage() =>
            _attackHandler.CalculateDamage();

        protected void SetCurrentAttackDamage(float damage) =>
            _currentAttackDamage = damage;
    }
}