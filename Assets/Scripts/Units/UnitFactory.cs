using StructureElements;
using UnityEngine;

namespace Units
{
    public class UnitFactory : MonoBehaviour
    {
        [SerializeField] private UnitPresenter _unitPrefab;

        private float _baseOffset = 3f;

        public void CreateUnit(
            Faction faction,
            BattleRole battleRole,
            int layerNumber,
            Vector3 basePosition)
        {
            UnitPresenter unit = CreatePresenter(_unitPrefab, null) as UnitPresenter;
            unit.gameObject.layer = layerNumber;

            if (layerNumber == LayerMask.NameToLayer("Enemy"))
                unit.transform.position = new Vector3(basePosition.x - _baseOffset, 0f, 0f);
            else
                unit.transform.position = new Vector3(basePosition.x + _baseOffset, 0f, 0f);

            unit.gameObject.SetActive(true);
        }

        private Presenter CreatePresenter(Presenter presenterTemplate, Transformable model)
        {
            Presenter presenter = Instantiate(presenterTemplate);
            presenter.Init(model);
            return presenter;
        }
    }
}
