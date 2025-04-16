using UnityEngine;
using Misc;

namespace Buildings
{
    public class MainBuildingPresenter : BuildingPresenter
    {
        [SerializeField] private UnitIncomeSourceScanner _unitScaner;

        public new MainBuilding Model => base.Model as MainBuilding;

        protected override void Awake()
        {
            base.Awake();

            StartCoroutine(Model.Spawner.GetSpawningCoroutine());
        }

        public override void Enable()
        {
            base.Enable();

            DamagableTarget.HalfHP += View.SetHalfHPAnimation;
            DamagableTarget.QuaterHP += View.SetQuaterHPAnimation;
            _unitScaner.UnitDetected += Model.Wallet.AddUnitAsIncomeSource;
        }

        public override void Disable()
        {
            base.Disable();

            DamagableTarget.HalfHP -= View.SetHalfHPAnimation;
            DamagableTarget.QuaterHP -= View.SetQuaterHPAnimation;
            _unitScaner.UnitDetected -= Model.Wallet.AddUnitAsIncomeSource;
        }
    }
}
