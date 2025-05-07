using System;
using UnityEngine;

namespace AttackSystem
{
    public class Health
    {
        private const float MinValue = 0;
        private const float Quater = 4;
        private const float Half = 2;

        private DamagableSetup _stats;
        private bool _isHalfHP = false;
        private bool _isQuaterHP = false;
        private UpgradeHandler _upgradeHandler;

        public event Action<float, float> ValueChanged;
        public event Action Dying;
        public event Action HalfHP;
        public event Action QuaterHP;

        public float Value { get; private set; }
        public float MaxValue { get; private set; }
        public bool IsAlive => Value > MinValue;

        public Health(DamagableSetup damagableSetup, UpgradeHandler upgradeHandler)
        {
            _stats = damagableSetup;
            _upgradeHandler = upgradeHandler;

            MaxValue = _upgradeHandler.GetIncreasedHealth(_stats);
            Value = MaxValue;
        }

        public void Reduce(float damage)
        {
            if (damage < 0)
                throw new ArgumentOutOfRangeException(nameof(damage));

            float newHealth = Mathf.Max(Value - damage, MinValue);
            UpdateValue(newHealth);

            if (IsAlive == false)
                Dying?.Invoke();
        }

        public void Reset()
        {
            Value = MaxValue;
            _isHalfHP = false;
            _isQuaterHP = false;
        }

        private void UpdateValue(float value)
        {
            Value = value;
            ValueChanged?.Invoke(value, MaxValue);

            if (MaxValue / Quater >= Value && _isQuaterHP == false)
            {
                _isQuaterHP = true;
                QuaterHP?.Invoke();
            }
            else if (MaxValue / Half >= Value && _isHalfHP == false)
            {
                _isHalfHP = true;
                HalfHP?.Invoke();
            }
        }
    }
}