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
        private int _minSpawnPositionZ = -5;
        private int _maxSpawnPositionZ = 5;
        private int _previousSpawnPosition = 0;

        private void Awake()
        {
            _unitsDictionary = new();

            foreach (UnitPresenter unit in _units)
            {
                if (_unitsDictionary.ContainsKey(unit.UnitSetup.Faction) == false)
                    _unitsDictionary.Add(unit.UnitSetup.Faction, new Dictionary<BattleRole, UnitPresenter>());

                _unitsDictionary[unit.UnitSetup.Faction].Add(unit.UnitSetup.BattleRole, unit);
            }
        }

        public void CreateUnit(UnitSetup setup, int layerNumber)
        {
            UnitPresenter unit = CreatePresenter(
                _unitsDictionary[setup.Faction][setup.BattleRole],
                new Unit(setup))
                as UnitPresenter;

            unit.gameObject.layer = layerNumber;

            int randomPositionZ = Random.Range(_minSpawnPositionZ, _maxSpawnPositionZ);

            while (_previousSpawnPosition == randomPositionZ)
                randomPositionZ = Random.Range(_minSpawnPositionZ, _maxSpawnPositionZ);

            unit.transform.position = new Vector3(_spawnPoint.position.x, _spawnPoint.position.y, randomPositionZ);
            _previousSpawnPosition = randomPositionZ;

            unit.gameObject.SetActive(true);

            unit.UnitMovementInput.SetInitialTarget(_enemyBase.transform); //Дубляж кода
            unit.DetectionSystem.SetInitialTarget(_enemyBase.transform);
        }

        private Presenter CreatePresenter(Presenter presenterTemplate, Transformable model)
        {
            Presenter presenter = Instantiate(presenterTemplate);
            presenter.Init(model);
            return presenter;
        }
    }
}
