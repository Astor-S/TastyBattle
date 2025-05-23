using UnityEngine;
using AttackSystem;
using AttackSystem.RangedAttackHandlers;

namespace Buildings
{
    public class TowerPresenter : BuildingPresenter
    {
        [SerializeField] private RangedAttackHandler _attackHandler;
        [SerializeField] private DetectionSystem _detectionSystem;
        [SerializeField] private DamagableTarget _enemyBase;
        [SerializeField] private AttackerAnimationEventHandler _attackerAnimation;

        public new AttackerSetup Stats => base.Stats as AttackerSetup;
        public new TowerView View => base.View as TowerView;

        private void Start()
        {
            _detectionSystem.Init(gameObject.layer, _enemyBase);
            _attackHandler.Init(Stats, UpgradesData);

            _attackerAnimation.enabled = true;
        }

        public override void Enable()
        {
            base.Enable();

            _attackHandler.AttackStarted += View.SetAttackingAnimation;
            _attackHandler.AttackStopped += View.StopAttackingAnimation;
        }

        public override void Disable()
        {
            base.Disable();

            _attackHandler.AttackStarted -= View.SetAttackingAnimation;
            _attackHandler.AttackStopped -= View.StopAttackingAnimation;
        }

        protected override void OnDying()
        {
            base.OnDying();

            if (_attackHandler != null)
                _attackHandler.enabled = false;

            if (_detectionSystem != null)
                _detectionSystem.enabled = false;
        }
    }
}