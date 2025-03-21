using UnityEngine;
using AttackSystem;

namespace Buildings
{
    public class TowerPresenter : BuildingPresenter
    {
        [SerializeField] private RangedAttackHandler _attackHandler;

        public new AttackerSetup Stats => base.Stats as AttackerSetup;

        private void Awake()
        {
            _attackHandler.Init(Stats);
        }
    }
}