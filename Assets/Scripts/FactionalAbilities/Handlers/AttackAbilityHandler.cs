using UnityEngine;

namespace FactionalAbilities.Handlers
{
    public class AttackAbilityHandler : MonoBehaviour
    {
        [SerializeField] UnitSetup _unitSetup;

        private float _baseAttackDamage;
        private float _currentAttackDamage;

        public float CurrentAttackDamage => _currentAttackDamage;

        private void Awake()
        {
            _baseAttackDamage = _unitSetup.AttackDamage;
            _currentAttackDamage = _baseAttackDamage;
        }

        protected virtual float GetBaseAttackDamage() =>
            _baseAttackDamage;

        protected virtual void SetCurrentAttackDamage(float damage) =>
            _currentAttackDamage = damage;
    }
}