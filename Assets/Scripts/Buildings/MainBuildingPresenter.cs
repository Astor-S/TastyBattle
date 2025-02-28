using StructureElements;

namespace Buildings
{
    public class MainBuildingPresenter : Presenter
    {
        public new MainBuilding Model => base.Model as MainBuilding;

        private void Start()
        {
            StartCoroutine(Model.Spawner.GetSpawningCoroutine());
        }
    }
}
