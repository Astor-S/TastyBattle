using StructureElements;
using System.Collections.Generic;
using UnityEngine;

namespace Units
{
    public class UnitFactory : MonoBehaviour
    {
        [SerializeField] private UnitPresenter[] _units;

        private Dictionary<Faction, Dictionary<BattleRole, UnitPresenter>> _unitsDictionary;
        private float _baseOffsetX = 5.5f;
        private float[] _baseOffsetsZ = new float[5] { -3f, -1.5f, 0f, 1.5f, 3f, };
        private int _currentOffsetZIndex = 0;

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
            unit.transform.position = new Vector3(basePosition.x, 0f, _baseOffsetsZ[_currentOffsetZIndex]);

            if (layerNumber == LayerMask.NameToLayer("Enemy"))
                unit.transform.position += Vector3.left * _baseOffsetX;
            else
                unit.transform.position += Vector3.right * _baseOffsetX;

            _currentOffsetZIndex = (_currentOffsetZIndex + 1) % _baseOffsetsZ.Length;

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
