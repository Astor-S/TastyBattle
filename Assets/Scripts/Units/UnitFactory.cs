using StructureElements;
using UnityEngine;

namespace Units
{
    public class UnitFactory : MonoBehaviour
    {
        [SerializeField] private Unit _unitPrefab;

        public void CreateUnit(
            Faction faction,
            BattleRole battleRole,
            Vector3 coordinates = default,
            Quaternion rotation = default)
        {
            Unit unit = CreatePresenter(_unitPrefab, null) as Unit;
            unit.transform.SetPositionAndRotation(coordinates, rotation);
        }

        private Presenter CreatePresenter(Presenter presenterTemplate, Transformable model)
        {
            Presenter presenter = Instantiate(presenterTemplate);
            presenter.Init(model);
            return presenter;
        }
    }
}
