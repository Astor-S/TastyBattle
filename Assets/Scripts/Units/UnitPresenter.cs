using StructureElements;
using UnityEngine;

namespace Units
{
    public class UnitPresenter : Presenter, IActivatable
    {
        [SerializeField] private UnitSetup _unitSetup;
        [SerializeField] private UnitMovementInput _unitMovementInput;
        [SerializeField] private AttackSystem _attackSystem;
        [SerializeField] private DamagableTarget _damageTarget;

        public new Unit Model => base.Model as Unit;
        public new UnitView View => base.View as UnitView;
        public UnitMovementInput UnitMovementInput => _unitMovementInput;
        public UnitSetup UnitSetup => _unitSetup;
        public Faction Faction => Model.Faction;
        public BattleRole BattleRole => Model.BattleRole;

        private void Start()
        {
            _attackSystem.Init(_unitSetup);
            View.SetWalkingAnimation();

            if (gameObject.layer == LayerMask.NameToLayer("Player"))
                View.SetColor(Color.blue);
            else if (gameObject.layer == LayerMask.NameToLayer("Enemy"))
                View.SetColor(Color.red);
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
