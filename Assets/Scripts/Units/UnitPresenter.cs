using StructureElements;
using UnityEngine;

namespace Units
{
    public class UnitPresenter : Presenter, IActivatable
    {
        [SerializeField] private UnitMovementInput _unitMovementInput;
        [SerializeField] private UnitStats _unitStats;
        [SerializeField] private AttackSystem _attackSystem;
        [SerializeField] private DamagableTarget _damageTarget;

        public UnitMovementInput UnitMovementInput => _unitMovementInput;
        public new UnitView View => base.View as UnitView;
        public Faction Faction => _unitStats.Faction;
        public BattleRole BattleRole => _unitStats.BattleRole;

        private void Start()
        {
            View.SetWalkingAnimation();

            SetColorSide();
        }

        private void SetColorSide()
        {
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
