using UnityEngine;
using AttackSystem.AttackHandlers;

namespace FactionalAbilities.Handlers
{
    public class AbilityHandler : MonoBehaviour
    {
        [SerializeField] private AttackHandler _attackHandler;

        private float _currentDamageBonus;

        public float CurrentDamageBonus => _currentDamageBonus;

        protected void SetCurrentDamageBonus(float damage) =>
            _currentDamageBonus = damage;
    }
}