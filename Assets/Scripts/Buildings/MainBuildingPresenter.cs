namespace Buildings
{
    public class MainBuildingPresenter : BuildingPresenter
    {
        public new MainBuilding Model => base.Model as MainBuilding;

        private void Awake()
        {
            StartCoroutine(Model.Spawner.GetSpawningCoroutine());
        }

        public override void OnEnable()
        {
            base.OnEnable();

            _damagableTarget.HalfHP += _buildingView.SetHalfHPAnimation;
            _damagableTarget.QuaterHP += _buildingView.SetQuaterHPAnimation;
        }

        public override void OnDisable()
        {
            base.OnDisable();

            _damagableTarget.HalfHP -= _buildingView.SetHalfHPAnimation;
            _damagableTarget.QuaterHP -= _buildingView.SetQuaterHPAnimation;
        }
    }
}
