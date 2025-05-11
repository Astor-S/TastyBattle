using System;
using UnityEngine;
using AttackSystem.Interfaces;

namespace AttackSystem
{
    public class DamagableTarget : MonoBehaviour, IDamagable, IIncomeSource
    {
        [SerializeField] private Collider _collider;

        private DamagableSetup _setup;
        private Health _health;
        private bool _isInvulnerable = false;

        public Health Health => _health;
        public bool IsAlive => _health.IsAlive;
        public bool IsBuilding => _setup.BattleRole == Units.BattleRole.Building;

        public event Action<DamagableTarget> Dying;
        public event Action HalfHP;
        public event Action QuaterHP;
        public event Action Inited;
        public event Action<int, IIncomeSource> ResourceRecieved;

        private void OnEnable()
        {
            _health.Reset();
            _collider.enabled = true;
            _health.Dying += Die;
            _health.HalfHP += OnHalfHP;
            _health.QuaterHP += OnQuaterHP;
        }

        private void OnDisable()
        {
            _health.Dying -= Die;
            _health.HalfHP -= OnHalfHP;
            _health.QuaterHP -= OnQuaterHP;
        }

        public void Init(DamagableSetup setup, UpgradesData upgradesData)
        {
            _setup = setup;

            _health = new Health(_setup, upgradesData);

            enabled = true;
            Inited?.Invoke();
        }

        public void TakeDamage(float damage)
        {
            if (_isInvulnerable == false)
                _health.Reduce(damage);                 
        }

        public void SetInvulnerable(bool invulnerable) =>
            _isInvulnerable = invulnerable;

        private void OnQuaterHP() =>
            QuaterHP?.Invoke();

        private void OnHalfHP() =>
            HalfHP?.Invoke();

        private void Die()
        {
            ResourceRecieved?.Invoke(_setup.Reward, this);
            Dying?.Invoke(this);

            _collider.enabled = false;

            enabled = false;
        }
    }
}