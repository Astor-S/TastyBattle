using StructureElements;
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

        public new Unit Model => base.Model as Unit;
        public new UnitView View => base.View as UnitView;
        public DetectionSystem DetectionSystem => _detectionSystem;
        public Faction Faction => _faction;
        public BattleRole BattleRole => _battleRole;

        private void Start()
        {
            _navMeshAgent.stoppingDistance = Model.Stats.ApproachDistance;
            View.SetWalkingAnimation();
            View.SetHealthBarColor();
        }

        public void Enable()
        {
            gameObject.layer = Mathf.RoundToInt(Mathf.Log(Model.Stats.OwnerMask, 2));

            if (_detectionSystem.gameObject.activeSelf == false)
                _detectionSystem.Init(gameObject.layer, Model.EnemyBase);

            if (_attackSystem.gameObject.activeSelf == false)
                _attackSystem.Init(Model.Stats);

            _damageTarget.Dying += View.SetDeathAnimation;
            _attackSystem.AttackStarted += View.SetAttackingAnimation;
            _attackSystem.AttackStopped += View.SetWalkingAnimation;
            _detectionSystem.TargetChanged += SetDestination;
        }

        public void Disable()
        {
            _damageTarget.Dying -= View.SetDeathAnimation;
            _attackSystem.AttackStarted -= View.SetAttackingAnimation;
            _attackSystem.AttackStopped -= View.SetWalkingAnimation;
            _detectionSystem.TargetChanged -= SetDestination;
        }

        private void SetDestination(DamagableTarget target)
        {
            _navMeshAgent.SetDestination(target.transform.position);
        }
    }
}
