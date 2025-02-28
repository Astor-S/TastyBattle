using StructureElements;

namespace Buildings
{
    public class MainBuildingPresenter : Presenter
    {

        public new MainBuilding Model => base.Model as MainBuilding;

       
            StartCoroutine(Model.Spawner.GetSpawningCoroutine());
    }
}
