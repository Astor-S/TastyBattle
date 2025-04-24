using System;
using System.Collections;
using UnityEngine;

namespace AttackSystem.AttackHandlers
{
    public class AttackHandler : MonoBehaviour
    {
        [SerializeField] private DetectionSystem _detectionSystem;

        private AttackerSetup _stats;
        private DamagableTarget _attackedTarget;
        protected WaitForFixedUpdate WaitForFixedUpdate = new WaitForFixedUpdate();

        public event Action AttackStarted;
        public event Action AttackStopped;

        public float AttackSpeedMultiplier { get; set; } = 1f;
        public bool IsAttacking => _attackedTarget != null && Vector3.SqrMagnitude(_attackedTarget.transform.position - transform.position) <= _stats.AttackDistance * _stats.AttackDistance;                                                 
        public DamagableTarget AttackedTarget => _attackedTarget;
        public float BaseAttackSpeed => _stats.AttackSpeed;
        protected AttackerSetup Stats => _stats;
        protected virtual float Damage => _stats.AttackDamage;

        private void OnEnable()
        {
            _detectionSystem.TargetChanged += ChangeTarget;
            StartCoroutine(nameof(Combat));
        }

        private void OnDisable()
        {
            _detectionSystem.TargetChanged -= ChangeTarget;
        }

        public void Init(AttackerSetup attackerSetup)
        {
            _stats = attackerSetup;

            gameObject.SetActive(true);
        }

        public virtual void Hit()
        {
            if (_attackedTarget != null)
                _attackedTarget.TakeDamage(CalculateDamage());
        }

        protected virtual float CalculateDamage() =>
           Damage;

        protected virtual IEnumerator Combat()
        {
            while (enabled)
            {
                if (_attackedTarget != null && IsAttacking)
                    StartAttack();
                else
                    StopAttack();

                yield return WaitForFixedUpdate;
            }
        }

        protected void StartAttack() =>
            AttackStarted?.Invoke();

        protected void StopAttack() =>
            AttackStopped?.Invoke();

        protected void ChangeTarget(DamagableTarget enemy) =>
            _attackedTarget = enemy;
    }
}