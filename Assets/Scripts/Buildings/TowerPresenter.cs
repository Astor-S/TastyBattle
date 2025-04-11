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

        public new AttackerSetup Stats => base.Stats as AttackerSetup;
        public new TowerView View => base.View as TowerView;

        public override void Enable()
        {
            base.Enable();

            _attackHandler.Init(Stats);
            _detectionSystem.Init(gameObject.layer, _enemyBase);

            _attackHandler.AttackStarted += View.SetAttackingAnimation;
            _attackHandler.AttackStopped += View.StopAttackingAnimation;
        }        
    }
}