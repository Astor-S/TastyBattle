using System;
using System.Collections;
using UnityEngine;

namespace AttackSystem.AttackHandlers
{
    public class AttackHandler : MonoBehaviour
    {
        private readonly Coroutine _timeUpdatingCoroutine; //???

        [SerializeField] private DetectionSystem _detectionSystem;

        protected WaitForFixedUpdate WaitForFixedUpdate;
        private AttackerSetup _stats;
        private DamagableTarget _attackedTarget;
        private float _distanceOffset = 0.5f;
        private bool _isAttacking;

        public event Action AttackStarted;
        public event Action AttackStopped;

        public float AttackSpeedMultiplier { get; set; } = 1f; //???
        public bool IsAbleToAttack => _attackedTarget != null && Vector3.SqrMagnitude(_attackedTarget.transform.position - transform.position) - _distanceOffset <= _stats.AttackDistance * _stats.AttackDistance;
        public DamagableTarget AttackedTarget => _attackedTarget;
        public float BaseAttackSpeed => _stats.AttackSpeed;
        protected AttackerSetup Stats => _stats;
        protected virtual float Damage => _stats.AttackDamage;

        private void OnEnable() =>
            _detectionSystem.TargetChanged += ChangeTarget;

        private void OnDisable() =>
            _detectionSystem.TargetChanged -= ChangeTarget;

        private void Start()
        {
            WaitForFixedUpdate = new WaitForFixedUpdate();

            StartCoroutine(nameof(Combat));
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
                if (_attackedTarget != null)
                {
                    if (IsAbleToAttack && _isAttacking == false)
                    {
                        StartAttack();
                        _isAttacking = true;
                    }
                    else if (IsAbleToAttack == false && _isAttacking)
                    {
                        StopAttack();
                        _isAttacking = false;
                    }
                }

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