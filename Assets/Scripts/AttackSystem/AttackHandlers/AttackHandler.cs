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
        private UpgradeHandler _upgradeHandler;
        private bool _isAttacking;

        public event Action AttackStarted;
        public event Action AttackStopped;

        public float AttackSpeedMultiplier { get; set; } = 1f;
        public bool IsAbleToAttack => _attackedTarget != null && Vector3.SqrMagnitude(_attackedTarget.transform.position - transform.position) <= _stats.AttackDistance * _stats.AttackDistance;
        public DamagableTarget AttackedTarget => _attackedTarget;
        public float BaseAttackSpeed => _stats.AttackSpeed;
        protected AttackerSetup Stats => _stats;
        protected virtual float Damage => _upgradeHandler.GetIncreasedDamage(_stats);

        private void OnEnable()
        {
            _detectionSystem.TargetChanged += ChangeTarget;
            StartCoroutine(nameof(Combat));
        }

        private void OnDisable() => 
            _detectionSystem.TargetChanged -= ChangeTarget;

        public void Init(AttackerSetup attackerSetup, UpgradeHandler upgradeHandler)
        {
            _stats = attackerSetup;
            _upgradeHandler = upgradeHandler;

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