using StructureElements;
using System;
using UnityEngine;
using UnityEngine.AI;

namespace Units
{
    public class UnitPresenter : Presenter, IActivatable
    {
        [SerializeField] private AttackSystem _attackSystem;
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
            _navMeshAgent.stoppingDistance = Model.Stats.AttackDistance;
            View.SetWalkingAnimation();
            View.SetHealthBarColor();
        }

        private void FixedUpdate()
        {
            if (_target != null)
                _navMeshAgent.SetDestination(_target.transform.position);
        }

        public void Enable()
        {
            gameObject.layer = Mathf.RoundToInt(Mathf.Log(Model.Stats.OwnerMask, 2));

            if (_damageTarget.enabled == false)
                _damageTarget.Init(Model.Stats);

            if (_detectionSystem.gameObject.activeSelf == false)
                _detectionSystem.Init(gameObject.layer, Model.EnemyBase);

            if (_attackSystem.gameObject.activeSelf == false)
                _attackSystem.Init(Model.Stats);

            _target = Model.EnemyBase;

            _damageTarget.Dying += DyingDelegate;
            _attackSystem.AttackStarted += View.SetAttackingAnimation;
            _attackSystem.AttackStopped += View.SetWalkingAnimation;
            _detectionSystem.TargetChanged += SetDestination;
        }

        public void Disable()
        {
            _damageTarget.Dying -= DyingDelegate;
            _attackSystem.AttackStarted -= View.SetAttackingAnimation;
            _attackSystem.AttackStopped -= View.SetWalkingAnimation;
            _detectionSystem.TargetChanged -= SetDestination;
        }

        private void SetDestination(DamagableTarget target) =>
            _target = target;
    }
}
