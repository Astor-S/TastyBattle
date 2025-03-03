namespace Buildings
{
    public class MainBuildingPresenter : BuildingPresenter
    {
        public new MainBuilding Model => base.Model as MainBuilding;

        private void Awake()
        {            
            StartCoroutine(Model.Spawner.GetSpawningCoroutine());
        }
    }
}
