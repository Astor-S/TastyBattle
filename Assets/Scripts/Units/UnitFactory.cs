using StructureElements;
using System.Collections.Generic;
using UnityEngine;

namespace Units
{
    public class UnitFactory : MonoBehaviour
    {
        [SerializeField] private UnitPresenter[] _units;
        [SerializeField] private DamagableTarget _enemyBase;
        [SerializeField] private Transform _spawnPoint;

        private Dictionary<Faction, Dictionary<BattleRole, UnitPresenter>> _unitsDictionary;

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
            int layerNumber)
        {
            UnitPresenter unit = CreatePresenter(_unitsDictionary[faction][battleRole], null) as UnitPresenter;
            unit.gameObject.layer = layerNumber;

            var randomPositionZ = Random.Range(-5, 5); 
            unit.transform.position = new Vector3(_spawnPoint.position.x, _spawnPoint.position.y, randomPositionZ);

            unit.gameObject.SetActive(true);

            unit.UnitMovementInput.SetEnemyBase(_enemyBase);
        }   

        private Presenter CreatePresenter(Presenter presenterTemplate, Transformable model)
        {
            Presenter presenter = Instantiate(presenterTemplate);
            presenter.Init(model);
            return presenter;
        }
    }
}
