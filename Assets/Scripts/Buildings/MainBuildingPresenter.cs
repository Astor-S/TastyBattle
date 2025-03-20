namespace Buildings
{
    public class MainBuildingPresenter : BuildingPresenter
    {
        public new MainBuilding Model => base.Model as MainBuilding;

        private void Awake()
        {
            StartCoroutine(Model.Spawner.GetSpawningCoroutine());
        }

        public override void Enable()
        {
            base.Enable();

            DamagableTarget.HalfHP += View.SetHalfHPAnimation;
            DamagableTarget.QuaterHP += View.SetQuaterHPAnimation;
        }

        public override void Disable()
        {
            base.Disable();

            DamagableTarget.HalfHP -= View.SetHalfHPAnimation;
            DamagableTarget.QuaterHP -= View.SetQuaterHPAnimation;
        }
    }
}
