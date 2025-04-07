using System;
using System.Collections;
using UnityEngine;

namespace AttackSystem.AttackHandlers
{
    public class AttackHandler : MonoBehaviour
    {
        private readonly Coroutine _timeUpdatingCoroutine;

        [SerializeField] private DetectionSystem _detectionSystem;

        private AttackerSetup _stats;
        private DamagableTarget _attackedTarget;
        private float _attackTimer;
        private float _attackSpeedMultiplier = 1f;
        private bool _isAttacking = false;

        public event Action AttackStarted;
        public event Action Hitting;
        public event Action AttackStopped;

        public DamagableTarget AttackedTarget => _attackedTarget;
        public bool IsAttacking => _isAttacking;
        protected AttackerSetup Stats => _stats;
        protected virtual float Damage => _stats.AttackDamage;
        protected float BaseAttackSpeed => _stats.AttackSpeed;
        protected float AttackSpeed => BaseAttackSpeed * _attackSpeedMultiplier;
        protected float AttackTimer => _attackTimer;

        public float AttackSpeedMultiplier
        {
            get { return _attackSpeedMultiplier; }
            set { _attackSpeedMultiplier = value; }
        }

        private void Start()
        {
            StartCoroutine(nameof(Combat));
            StartCoroutine(nameof(StartCooldown));
        }

        private void OnEnable()
        {
            _detectionSystem.TargetChanged += ChangeTarget;
        }

        private void OnDisable()
        {
            _detectionSystem.TargetChanged -= ChangeTarget;
        }

        private void FixedUpdate()
        {
            if (_attackedTarget != null && Vector3.SqrMagnitude(_attackedTarget.transform.position - transform.position) <= _stats.AttackDistance * _stats.AttackDistance)
                _isAttacking = true;
            else
                _isAttacking = false;
        }

        public void Init(AttackerSetup attackerSetup)
        {
            _stats = attackerSetup;

            gameObject.SetActive(true);
        }

        protected virtual void Hit()
        {
            if (_attackedTarget != null)
            {
                Hitting?.Invoke();
                _attackedTarget.TakeDamage(CalculateDamage());
            }
        }

        protected virtual float CalculateDamage() =>
           Damage;

        protected virtual IEnumerator Combat()
        {
            WaitForFixedUpdate waitForFixedUpdate = new WaitForFixedUpdate();

            while (enabled)
            {
                if (_attackedTarget != null && _isAttacking)
                {
                    StartAttack();

                    if (_attackTimer >= BaseAttackSpeed)
                    {
                        Hit();
                        ResetTimer();
                    }
                }
                else
                {
                    StopAttack();
                }

                yield return waitForFixedUpdate;
            }
        }

        protected void ResetTimer()
        {
            _attackTimer = 0f;
        }

        protected void StartAttack()
        {
            AttackStarted?.Invoke();
        }

        protected void StopAttack()
        {
            AttackStopped?.Invoke();
        }

        private IEnumerator StartCooldown()
        {
            WaitForFixedUpdate waitForFixedUpdate = new WaitForFixedUpdate();

            while (enabled)
            {
                if (_attackTimer < BaseAttackSpeed)
                    _attackTimer += Time.fixedDeltaTime;

                yield return waitForFixedUpdate;
            }
        }

        private void ChangeTarget(DamagableTarget enemy) =>
            _attackedTarget = enemy;
    }
}