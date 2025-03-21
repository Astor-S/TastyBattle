using UnityEngine;

namespace Buildings
{
    public class TowerPresenter : BuildingPresenter
    {
        [SerializeField] private RangedAttackHandler _attackHandler;
        [SerializeField] private DetectionSystem _detectionSystem;
        [SerializeField] private DamagableTarget _enemyBase;

        public new AttackerSetup Stats => base.Stats as AttackerSetup;

        private void Start()
        {
            _attackHandler.Init(Stats);
            _detectionSystem.Init(gameObject.layer, _enemyBase);
        }
    }
}