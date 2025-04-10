using System;
using System.Collections;
using UnityEngine;

namespace AttackSystem.AttackHandlers
{
    public class AttackHandler : MonoBehaviour
    {
        private readonly Coroutine _timeUpdatingCoroutine; //???

        [SerializeField] private DetectionSystem _detectionSystem;

        private AttackerSetup _stats;
        private DamagableTarget _attackedTarget;
        private float _attackTimer;
        private WaitForFixedUpdate _waitForFixedUpdate;

        public event Action AttackStarted;
        public event Action Hitting;
        public event Action AttackStopped;

        public float AttackSpeedMultiplier { get; set; } = 1f; //???
        //protected float AttackSpeed => BaseAttackSpeed * AttackSpeedMultiplier;
        //protected float AttackTimer => _attackTimer;            
        public DamagableTarget AttackedTarget => _attackedTarget;
        protected AttackerSetup Stats => _stats;
        protected virtual float Damage => _stats.AttackDamage;
        public float BaseAttackSpeed => _stats.AttackSpeed;

        private void Start()
        {
            _waitForFixedUpdate = new WaitForFixedUpdate();

            StartCoroutine(nameof(Combat));
            //StartCoroutine(nameof(StartCooldown));
        }

        private void OnEnable() =>
            _detectionSystem.TargetChanged += ChangeTarget;

        private void OnDisable() =>
            _detectionSystem.TargetChanged -= ChangeTarget;

        protected bool IsAttacking()
        {
            if (_attackedTarget != null && Vector3.SqrMagnitude(_attackedTarget.transform.position - transform.position) <= _stats.AttackDistance * _stats.AttackDistance)
                return true;

            return false;
        }

        public void Init(AttackerSetup attackerSetup)
        {
            _stats = attackerSetup;

            gameObject.SetActive(true);
        }

        public virtual void Hit()
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
            while (enabled)
            {
                if (_attackedTarget != null && IsAttacking())
                {
                    StartAttack();

                    //if (_attackTimer >= BaseAttackSpeed)
                    //{
                    //    Hit();
                    //    ResetTimer();
                    //}
                }
                else
                {
                    StopAttack();
                }

                yield return _waitForFixedUpdate;
            }
        }

        //protected void ResetTimer() => 
        //    _attackTimer = 0f;

        protected void StartAttack() =>
            AttackStarted?.Invoke();

        protected void StopAttack() =>
            AttackStopped?.Invoke();

        //private IEnumerator StartCooldown()
        //{
        //    while (enabled)
        //    {
        //        if (_attackTimer < BaseAttackSpeed)
        //            _attackTimer += Time.fixedDeltaTime;

        //        yield return _waitForFixedUpdate;
        //    }
        //}

        protected void ChangeTarget(DamagableTarget enemy) =>
            _attackedTarget = enemy;
    }
}