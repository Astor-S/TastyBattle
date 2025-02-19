using StructureElements;
using UnityEngine;

namespace Units
{
    public class UnitPresenter : Presenter, IActivatable
    {
        [SerializeField] private UnitMovementTargetFinder _unitMovementTargetFinder;
        [SerializeField] private UnitStats _unitStats;
        [SerializeField] private AbstractAttacker _attacker;

        public new UnitVew View => base.View as UnitVew;

        public Faction Faction => _unitStats.Faction;
        
        public BattleRole BattleRole => _unitStats.BattleRole;

        private void Start()
        {
            View.SetWalkingAnimation();
        }

        public void Enable()
        {
            _attacker.AttackStarted += View.SetAttackingAnimation;
            _attacker.AttackStopped += View.SetWalkingAnimation;
        }

        public void Disable()
        {
            _attacker.AttackStarted -= View.SetAttackingAnimation;
            _attacker.AttackStopped -= View.SetWalkingAnimation;
        }
    }
}
