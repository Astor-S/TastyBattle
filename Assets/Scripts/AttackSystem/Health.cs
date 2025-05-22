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
        private UpgradesData _upgradesData;
        private bool _isHalfHP = false;
        private bool _isQuaterHP = false;

        public event Action<float, float> ValueChanged;
        public event Action Dying;
        public event Action HalfHP;
        public event Action QuaterHP;

        public float Value { get; private set; }
        public float MaxValue { get; private set; }

        public bool IsAlive => Value > MinValue;

        public Health(DamagableSetup damagableSetup, UpgradesData upgradesData)
        {
            _stats = damagableSetup;
            _upgradesData = upgradesData;

            if (_stats.BattleRole == Units.BattleRole.Building)
            {
                _upgradesData.BuildingHealthUpgraded += OnUpgraded;
                MaxValue = _upgradesData.GetIncreasedBuldingHealth(damagableSetup);
            }
            else
            {
                _upgradesData.UnitHealthUpgraded += OnUpgraded;
                MaxValue = _upgradesData.GetIncreasedUnitHealth(damagableSetup);
            }
             
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

        private void OnUpgraded()
        {
            float difference;

            if (_stats.BattleRole == Units.BattleRole.Building)
                difference = _upgradesData.GetIncreasedBuldingHealth(_stats) - MaxValue;
            else
                difference = _upgradesData.GetIncreasedUnitHealth(_stats) - MaxValue;

            MaxValue += difference;
            Value += difference;

            ValueChanged?.Invoke(Value, MaxValue);
        }

        private void UpdateValue(float value)
        {
            Value = value;
            ValueChanged?.Invoke(Value, MaxValue);

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