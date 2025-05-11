using UnityEngine;
using AttackSystem.AttackHandlers;

namespace FactionalAbilities.Handlers
{
    public class AttackAbilityHandler : MonoBehaviour
    {
        [SerializeField] private AttackHandler _attackHandler;

        private float _currentAttackDamage;

        public float CurrentAttackDamage => _currentAttackDamage;

        protected float GetBaseAttackDamage()
        {
            Debug.Log("Calculate" + _attackHandler.CalculateDamage());
            return _attackHandler.CalculateDamage();
        }

        protected void SetCurrentAttackDamage(float damage) =>
            _currentAttackDamage = damage;
    }
}