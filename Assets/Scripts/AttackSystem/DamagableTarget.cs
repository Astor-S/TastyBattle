using System;
using System.Collections;
using UnityEngine;
using AttackSystem.Interfaces;

namespace AttackSystem
{
    public class DamagableTarget : MonoBehaviour, IDamagable
    {
        [SerializeField] private Collider _collider;
        [SerializeField] private Rigidbody _rigidbody;

        private DamagableSetup _setup;
        private Health _health;
        private float _deathTime = 1.5f;

        public Health Health => _health;
        public bool IsAlive => _health.IsAlive;

        public event Action<DamagableTarget> Dying;
        public event Action HalfHP;
        public event Action QuaterHP;
        public event Action Inited;

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
            Dying?.Invoke(this);
            StartCoroutine(StartDying());
        }

        private IEnumerator StartDying()
        {
            _collider.enabled = false;
            _rigidbody.isKinematic = true;

            enabled = false;

            yield return new WaitForSeconds(_deathTime);

            Destroy(gameObject);
        }
    }
}