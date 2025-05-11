using UnityEngine;
using AttackSystem;

namespace FactionalAbilities.Handlers
{
    public class WatermelonAbilityHandler : AttackAbilityHandler
    {
        private const float DamageMultiplierBase = 1f;

        [SerializeField] private WatermelonAbility _watermelonAbility;
        [SerializeField] private DamagableTarget _damagableTarget;  

        private bool _isDamageBoostActive = false;

        private void OnEnable()
        {
            _damagableTarget.Health.ValueChanged += OnHealthChanged;

            ApplyBaseDamage();
        }

        private void OnDisable()
        {
            _damagableTarget.Health.ValueChanged -= OnHealthChanged;
        }

        private void OnHealthChanged(float currentHealth, float maxHealth)
        {
            float healthPercentage = currentHealth / maxHealth;

            if (healthPercentage < _watermelonAbility.DamageBoostThreshold && _isDamageBoostActive == false)
                ApplyDamageBoost();
            else if (healthPercentage >= _watermelonAbility.DamageBoostThreshold && _isDamageBoostActive)
                ApplyBaseDamage();
        }

        private void ApplyDamageBoost()
        {
            _isDamageBoostActive = true;
            float currentBonusDamage = DamageMultiplierBase + _watermelonAbility.DamageBoostPercentage;
            SetCurrentDamageBonus(currentBonusDamage);
        }

        private void ApplyBaseDamage()
        {
            _isDamageBoostActive = false;
            float baseDamage = DamageMultiplierBase;
            SetCurrentDamageBonus(baseDamage);
        }
    }
}