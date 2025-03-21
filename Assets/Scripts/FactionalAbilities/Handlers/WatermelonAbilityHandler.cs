using UnityEngine;

namespace FactionalAbilities.Handlers
{
    public class WatermelonAbilityHandler : MonoBehaviour
    {
        private const float DamageMultiplierBase = 1f;

        [SerializeField] private WatermelonAbility _watermelonAbility;
        [SerializeField] private Health _health;  
        [SerializeField] private UnitSetup _unitSetup;

        private float _baseAttackDamage;
        private float _currentAttackDamage;
        private bool _isDamageBoostActive = false;

        public float CurrentAttackDamage => _currentAttackDamage;

        private void Awake()
        {
            _baseAttackDamage = _unitSetup.AttackDamage;
            _currentAttackDamage = _baseAttackDamage;
        }

        private void OnEnable()
        {
            _health.ValueChanged += OnHealthChanged;
        }

        private void OnDisable()
        {
            _health.ValueChanged -= OnHealthChanged;
        }

        private void OnHealthChanged(float currentHealth, float maxHealth)
        {
            float healthPercentage = currentHealth / maxHealth;

            if (healthPercentage < _watermelonAbility.DamageBoostThreshold && _isDamageBoostActive == false)
                ApplyDamageBoost();
            else if (healthPercentage >= _watermelonAbility.DamageBoostThreshold && _isDamageBoostActive)
                RemoveDamageBoost();
        }

        private void ApplyDamageBoost()
        {
            _isDamageBoostActive = true;
            _currentAttackDamage = _baseAttackDamage * (DamageMultiplierBase + _watermelonAbility.DamageBoostPercentage);
            Debug.Log($"[{gameObject.name}] Watermelon Ability Activated! Damage increased to {_currentAttackDamage}");
        }

        private void RemoveDamageBoost()
        {
            _isDamageBoostActive = false;
            _currentAttackDamage = _baseAttackDamage;
            Debug.Log($"[{gameObject.name}] Watermelon Ability Deactivated! Damage returned to {_currentAttackDamage}");
        }
    }
}