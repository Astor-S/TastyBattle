using StructureElements;
using UnityEngine;

namespace Units
{
    public class UnitPresenter : Presenter, IActivatable
    {
        [SerializeField] private UnitMovementInput _unitMovementInput;
        [SerializeField] private UnitStats _unitStats;
        [SerializeField] private AttackSystem _attackSystem;

        public new UnitVew View => base.View as UnitVew;

        public Faction Faction => _unitStats.Faction;
        
        public BattleRole BattleRole => _unitStats.BattleRole;

        private void Start()
        {
            View.SetWalkingAnimation();
        }

        public void Enable()
        {
            _attackSystem.AttackStarted += View.SetAttackingAnimation;
            _attackSystem.AttackStopped += View.SetWalkingAnimation;
        }

        public void Disable()
        {
            _attackSystem.AttackStarted -= View.SetAttackingAnimation;
            _attackSystem.AttackStopped -= View.SetWalkingAnimation;
        }
    }
}
