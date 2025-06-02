using System;
using UnityEngine;
using UnityEngine.AI;
using AttackSystem;
using AttackSystem.AttackHandlers;
using FactionalAbilities.Handlers.Debuffs;
using StructureElements;
using StructureElements.Interfaces;
using Upgrades;
using DetectionSystem;

namespace Units
{
    public class UnitPresenter : Presenter, IActivatable
    {
        private const string Player = nameof(Player);
        private const float DefaultAttackSpeedMultiplier = 1f;

        [SerializeField] private AttackHandler _attackHandler;
        [SerializeField] private DetectionController _detectionSystem;
        [SerializeField] private DamagableTarget _damageTarget;
        [SerializeField] private NavMeshAgent _navMeshAgent;
        [SerializeField] private Faction _faction;
        [SerializeField] private BattleRole _battleRole;

        private float _defaultSpeed;
        private UpgradesData _upgradesData;
        private Action<DamagableTarget> _dyingDelegate;

        public event Action<UnitPresenter> OnUnitDying;
        public event Action<UnitPresenter> Releasing;

        public new Unit Model => base.Model as Unit;
        public new UnitView View => base.View as UnitView;
        public DetectionController DetectionSystem => _detectionSystem;
        public Faction Faction => _faction;
        public BattleRole BattleRole => _battleRole;
        protected AttackHandler AttackHandler => _attackHandler;
        protected NavMeshAgent NavMeshAgent => _navMeshAgent;

        private void Awake()
        {
            gameObject.layer = Model.OwnerMask;
            _upgradesData = gameObject.layer == LayerMask.NameToLayer(Player) ? UpgradesController.Player : UpgradesController.Enemy;
            _dyingDelegate = (_) => OnDying();

            _navMeshAgent.updateRotation = false;
            NavMesh.avoidancePredictionTime = 0.5f;

            _navMeshAgent.stoppingDistance = 0f;
            _navMeshAgent.speed = _upgradesData.GetIncreasedSpeed(Model.Stats);
            _defaultSpeed = _upgradesData.GetIncreasedSpeed(Model.Stats);

            if (_damageTarget.enabled == false)
                _damageTarget.Init(Model.Stats, _upgradesData);

            if (_detectionSystem.gameObject.activeSelf == false)
                _detectionSystem.Init(gameObject.layer, Model.EnemyBase, _battleRole);

            if (_attackHandler.gameObject.activeSelf == false)
                _attackHandler.Init(Model.Stats, _upgradesData);
        }

        protected virtual void FixedUpdate()
        {
            if (_detectionSystem.CurrentTarget != null && _navMeshAgent.enabled == true)
            {
                Vector3 destination = Vector3.MoveTowards(_detectionSystem.CurrentTarget.transform.position, transform.position, Model.Stats.AttackDistance - 0.5f);
                _navMeshAgent.SetDestination(destination);
            }
        }

        public virtual void Enable()
        {
            View.SetWalkingAnimation();

            _damageTarget.enabled = true;
            _navMeshAgent.enabled = true;
            _detectionSystem.enabled = true;
            _attackHandler.enabled = true;

            _damageTarget.Dying += _dyingDelegate;
            _attackHandler.AttackStarted += View.SetAttackingAnimation;
            _attackHandler.AttackStopped += View.SetWalkingAnimation;
            View.Decayed += OnDecayed;
        }

        public virtual void Disable()
        {
            _damageTarget.Dying -= _dyingDelegate;
            _attackHandler.AttackStarted -= View.SetAttackingAnimation;
            _attackHandler.AttackStopped -= View.SetWalkingAnimation;
            View.Decayed -= OnDecayed;
        }

        public void SetAgentSpeed(float speed) =>
            _navMeshAgent.speed = speed;

        public void SetAttackSpeedMultiplier(float attackSpeedMultiplier) =>
            _attackHandler.AttackSpeedMultiplier = attackSpeedMultiplier;

        public void ResetAgentSpeed() =>
            _navMeshAgent.speed = _defaultSpeed;

        public void ResetAttackSpeedMultiplier() =>
            _attackHandler.AttackSpeedMultiplier = DefaultAttackSpeedMultiplier;

        protected void OnDying()
        {
            View.SetDeathAnimation();

            _damageTarget.enabled = false;
            _attackHandler.enabled = false;
            _navMeshAgent.enabled = false;
            _detectionSystem.enabled = false;
            ResetEffects();

            OnUnitDying?.Invoke(this);
        }

        private void ResetEffects()
        {
            ResetAgentSpeed();
            ResetAttackSpeedMultiplier();

            if (TryGetComponent<DebuffHandler>(out var debuffHandler))
                Destroy(debuffHandler);
        }

        private void OnDecayed() =>
            Releasing?.Invoke(this);
    }
}