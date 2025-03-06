using StructureElements;
using UnityEngine;

namespace Units
{
    public class UnitPresenter : Presenter, IActivatable
    {
        [SerializeField] private UnitMovementInput _unitMovementInput;
        [SerializeField] private AttackSystem _attackSystem;
        [SerializeField] private DamagableTarget _damageTarget;
        [SerializeField] Faction _faction;
        [SerializeField] BattleRole _battleRole;

        public new Unit Model => base.Model as Unit;
        public new UnitView View => base.View as UnitView;
        public UnitMovementInput UnitMovementInput => _unitMovementInput;
        public Faction Faction => _faction;
        public BattleRole BattleRole => _battleRole;

        private void Start()
        {
            _attackSystem.Init(Model.Stats);
            _unitMovementInput.Init(Model.Stats);
            View.SetWalkingAnimation();
            View.SetHealthBarColor();
        }

        public void Enable()
        {
            _damageTarget.Died += View.SetDeathAnimation;
            _attackSystem.AttackStarted += View.SetAttackingAnimation;
            _attackSystem.AttackStopped += View.SetWalkingAnimation;
        }

        public void Disable()
        {
            _damageTarget.Died -= View.SetDeathAnimation;
            _attackSystem.AttackStarted -= View.SetAttackingAnimation;
            _attackSystem.AttackStopped -= View.SetWalkingAnimation;
        }
    }
}
