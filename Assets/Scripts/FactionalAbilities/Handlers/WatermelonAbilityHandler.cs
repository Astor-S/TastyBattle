using StructureElements;
using UnityEngine;

namespace FactionalAbilities.Handlers
{
    public class WatermelonAbilityHandler : MonoBehaviour
    {
        private const float DamageMultiplierBase = 1f;

        [SerializeField] private WatermelonAbility _watermelonAbility;
        [SerializeField] private DamagableTarget _damagableTarget;  
        [SerializeField] private UnitSetup _unitSetup;

        private float _baseAttackDamage;
        private float _currentAttackDamage;
        private bool _isDamageBoostActive = false;
        private bool _inited = false;

        public float CurrentAttackDamage => _currentAttackDamage;

        private void Awake()
        {
            _baseAttackDamage = _unitSetup.AttackDamage;
            _currentAttackDamage = _baseAttackDamage;
        }

        private void OnEnable()
        {
            if (_inited)
                _damagableTarget.Health.ValueChanged += OnHealthChanged;
            else
                _damagableTarget.Inited += OnDamagableTargetInited;
        }

        private void OnDisable()
        {
            if (_inited)
                _damagableTarget.Health.ValueChanged -= OnHealthChanged;
            else
                _damagableTarget.Inited -= OnDamagableTargetInited;
        }

        private void OnDamagableTargetInited()
        {
            _inited = true;
            _damagableTarget.Health.ValueChanged += OnHealthChanged;
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