namespace Buildings
{
    public class MainBuildingPresenter : BuildingPresenter
    {
        public new MainBuilding Model => base.Model as MainBuilding;

        private void Awake() =>
            StartCoroutine(Model.Spawner.GetSpawningCoroutine());

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
