using System;
using UnityEngine;
using UnityEngine.AI;
using StructureElements;
using AttackSystem;
using AttackSystem.AttackHandlers;

namespace Units
{
    public class UnitPresenter : Presenter, IActivatable
    {
        [SerializeField] private AttackHandler _attackHandler;
        [SerializeField] private DetectionSystem _detectionSystem;
        [SerializeField] private DamagableTarget _damageTarget;
        [SerializeField] private NavMeshAgent _navMeshAgent;
        [SerializeField] private Faction _faction;
        [SerializeField] private BattleRole _battleRole;
        
        private float _defaultSpeed;
        private float _defaultAttackSpeed;

        private Action<DamagableTarget> DyingDelegate;

        public new Unit Model => base.Model as Unit;
        public new UnitView View => base.View as UnitView;
        public DetectionSystem DetectionSystem => _detectionSystem;
        public Faction Faction => _faction;
        public BattleRole BattleRole => _battleRole;

        protected AttackHandler AttackHandler => _attackHandler;
        protected NavMeshAgent NavMeshAgent => _navMeshAgent;

        private void FixedUpdate()
        {
            if (_detectionSystem.CurrentTarget != null)
            {
                if (_attackHandler.IsAttacking == false)
                    _navMeshAgent.SetDestination(_detectionSystem.CurrentTarget.transform.position);
            }
        }

        public virtual void Enable()
        {
            gameObject.layer = Mathf.RoundToInt(Mathf.Log(Model.Stats.OwnerMask, 2));
            _navMeshAgent.updateRotation = false;
            _navMeshAgent.stoppingDistance = Model.Stats.AttackDistance;
            _navMeshAgent.speed = Model.Stats.MovementSpeed;
             _defaultSpeed = Model.Stats.MovementSpeed;
            NavMesh.avoidancePredictionTime = 0.5f;
            View.SetWalkingAnimation();
            View.SetHealthBarColor();

            if (_damageTarget.enabled == false)
                _damageTarget.Init(Model.Stats);

            if (_detectionSystem.gameObject.activeSelf == false)
                _detectionSystem.Init(gameObject.layer, Model.EnemyBase);

            if (_attackHandler.gameObject.activeSelf == false)
                _attackHandler.Init(Model.Stats);

            DyingDelegate = (_) =>
            {
                View.SetDeathAnimation();
                _navMeshAgent.enabled = false;
            };

            _damageTarget.Dying += DyingDelegate;
            _attackHandler.AttackStarted += View.SetAttackingAnimation;
            _attackHandler.AttackStopped += View.SetWalkingAnimation;
        }

        public virtual void Disable()
        {
            _damageTarget.Dying -= DyingDelegate;
            _attackHandler.AttackStarted -= View.SetAttackingAnimation;
            _attackHandler.AttackStopped -= View.SetWalkingAnimation;
        }

        public void SetAgentSpeed(float speed) =>
            _navMeshAgent.speed = speed;

        public void SetAttackSpeed(float attackSpeed)
        {
            //_attackHandler.AttackSpeedMultiplier = attackSpeed;
        }

        public void ResetAgentSpeed() =>
            _navMeshAgent.speed = _defaultSpeed;

        public void ResetAttackSpeed()
        {
            //_attackHandler.AttackSpeedMultiplier = _defaultAttackSpeed;
        }
    }
}