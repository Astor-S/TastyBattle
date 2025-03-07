using UnityEngine;

namespace Buildings
{
    public class MainBuildingPresenter : BuildingPresenter
    {
        [SerializeField] private Health _health;

        public new MainBuilding Model => base.Model as MainBuilding;

        private void Awake()
        {
            StartCoroutine(Model.Spawner.GetSpawningCoroutine());
            _health.Init(Stats);
        }

        public override void Enable()
        {
            base.Enable();

            _damagableTarget.HalfHP += View.SetHalfHPAnimation;
            _damagableTarget.QuaterHP += View.SetQuaterHPAnimation;
        }

        public override void Disable()
        {
            base.Disable();

            _damagableTarget.HalfHP -= View.SetHalfHPAnimation;
            _damagableTarget.QuaterHP -= View.SetQuaterHPAnimation;
        }
    }
}
