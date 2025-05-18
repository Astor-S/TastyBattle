using System;
using System.Collections;
using UnityEngine;

namespace AttackSystem.AttackHandlers
{
    public class AttackHandler : MonoBehaviour
    {
        [SerializeField] private DetectionSystem _detectionSystem;

        private AttackerSetup _stats;
        protected WaitForFixedUpdate WaitForFixedUpdate = new WaitForFixedUpdate();
        private UpgradesData _upgradesData;
        private bool _isAttacking;
        private Coroutine _combat;

        public event Action AttackStarted;
        public event Action AttackStopped;

        public bool ReadyToAttack =>
            Vector3.SqrMagnitude(AttackedTarget.transform.position - transform.position) <= _stats.AttackDistance * _stats.AttackDistance;

        public float AttackSpeedMultiplier { get; set; } = 1f;
        public DamagableTarget AttackedTarget => _detectionSystem.CurrentTarget;
        public float BaseAttackSpeed => _stats.AttackSpeed;
        protected AttackerSetup Stats => _stats;
        protected UpgradesData UpgradesData => _upgradesData;

        private void OnEnable()
        {
            _isAttacking = false;
            _combat = StartCoroutine(Combat());
        }

        private void OnDisable()
        {
            StopCoroutine(_combat);
            _combat = null;
        }

        public void Init(AttackerSetup attackerSetup, UpgradesData upgradesData)
        {
            _stats = attackerSetup;
            _upgradesData = upgradesData;

            gameObject.SetActive(true);
        }

        public virtual void Hit()
        {
            if (AttackedTarget != null)
                AttackedTarget.TakeDamage(CalculateDamage());
        }

        public virtual float CalculateDamage() =>
           _upgradesData.GetIncreasedDamage(_stats);

        protected virtual IEnumerator Combat()
        {
            while (enabled)
            {
                yield return WaitForFixedUpdate;

                if (ReadyToAttack && _isAttacking == false)
                {
                    StartAttack();
                    _isAttacking = true;
                }
                else if (ReadyToAttack == false && _isAttacking)
                {
                    StopAttack();
                    _isAttacking = false;
                }
            }
        }

        protected void StartAttack() =>
            AttackStarted?.Invoke();

        protected void StopAttack() =>
            AttackStopped?.Invoke();
    }
}