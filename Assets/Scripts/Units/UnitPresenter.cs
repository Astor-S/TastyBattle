using StructureElements;
using System;
using UnityEngine;
using UnityEngine.AI;

namespace Units
{
    public class UnitPresenter : Presenter, IActivatable
    {
        [SerializeField] private AttackHandler _attackHandler;
        [SerializeField] private DetectionSystem _detectionSystem;
        [SerializeField] private DamagableTarget _damageTarget;
        [SerializeField] private NavMeshAgent _navMeshAgent;
        [SerializeField] Faction _faction;
        [SerializeField] BattleRole _battleRole;

        private DamagableTarget _target = null;

        public new Unit Model => base.Model as Unit;
        public new UnitView View => base.View as UnitView;
        public DetectionSystem DetectionSystem => _detectionSystem;
        public Faction Faction => _faction;
        public BattleRole BattleRole => _battleRole;
        private Action<DamagableTarget> DyingDelegate => (_) => View.SetDeathAnimation();

        private void Start()
        {
            _navMeshAgent.stoppingDistance = Model.Stats.AttackDistance + 0.05f;
            _navMeshAgent.speed = Model.Stats.MovementSpeed;
            View.SetWalkingAnimation();
            View.SetHealthBarColor();
        }

        private void FixedUpdate()
        {
            if (_target != null)
            {
                if (_attackHandler.IsAttacking == false)
                    _navMeshAgent.SetDestination(_target.transform.position);

                transform.LookAt(_target.transform.position);
            }
        }

        public void Enable()
        {
            gameObject.layer = Mathf.RoundToInt(Mathf.Log(Model.Stats.OwnerMask, 2));

            if (_damageTarget.enabled == false)
                _damageTarget.Init(Model.Stats);

            if (_detectionSystem.gameObject.activeSelf == false)
                _detectionSystem.Init(gameObject.layer, Model.EnemyBase);

            if (_attackHandler.gameObject.activeSelf == false)
                _attackHandler.Init(Model.Stats);

            _target = Model.EnemyBase;

            _damageTarget.Dying += DyingDelegate;
            _attackHandler.AttackStarted += View.SetAttackingAnimation;
            _attackHandler.AttackStopped += View.SetWalkingAnimation;
            _detectionSystem.TargetChanged += SetDestination;
        }

        public void Disable()
        {
            _damageTarget.Dying -= DyingDelegate;
            _attackHandler.AttackStarted -= View.SetAttackingAnimation;
            _attackHandler.AttackStopped -= View.SetWalkingAnimation;
            _detectionSystem.TargetChanged -= SetDestination;
        }

        private void SetDestination(DamagableTarget target) =>
            _target = target;
    }
}