using System;
using UnityEngine;
using AttackSystem.Interfaces;

namespace AttackSystem
{
    public class DamagableTarget : MonoBehaviour, IDamagable, IIncomeSource
    {
        [SerializeField] private Collider _collider;
        [SerializeField] private Rigidbody _rigidbody;

        private DamagableSetup _setup;
        private Health _health;

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

        public void Init(DamagableSetup setup)
        {
            _setup = setup;
            _health = new Health(_setup);

            enabled = true;
            Inited?.Invoke();
        }

        private void OnQuaterHP() =>
            QuaterHP?.Invoke();

        private void OnHalfHP() =>
            HalfHP?.Invoke();

        public void TakeDamage(float damage) =>
            _health.Reduce(damage);

        private void Die()
        {
            ResourceRecieved?.Invoke(_setup.Reward, this);
            Dying?.Invoke(this);

            _collider.enabled = false;
            _rigidbody.isKinematic = true;

            enabled = false;            
        }
    }
}