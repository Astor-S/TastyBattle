using StructureElements;
using System.Collections.Generic;
using UnityEngine;

namespace Units
{
    public class UnitFactory : MonoBehaviour
    {
        [SerializeField] private UnitPresenter[] _units;

        private Dictionary<Faction, Dictionary<BattleRole, UnitPresenter>> _unitsDictionary;
        private float _baseOffset = 5.5f;

        private void OnValidate()
        {
            _unitsDictionary = new();

            foreach (UnitPresenter unit in _units)
            {
                if (_unitsDictionary.ContainsKey(unit.Faction) == false)
                    _unitsDictionary.Add(unit.Faction, new Dictionary<BattleRole, UnitPresenter>());

                _unitsDictionary[unit.Faction].Add(unit.BattleRole, unit);
            }
        }

        public void CreateUnit(
            Faction faction,
            BattleRole battleRole,
            int layerNumber,
            Vector3 basePosition)
        {
            UnitPresenter unit = CreatePresenter(_unitsDictionary[faction][battleRole], null) as UnitPresenter;
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
