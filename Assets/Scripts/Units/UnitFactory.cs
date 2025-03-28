using System.Collections.Generic;
using UnityEngine;
using AttackSystem;
using StructureElements;

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
                if (_unitsDictionary.ContainsKey(unit.Faction) == false)
                    _unitsDictionary.Add(unit.Faction, new Dictionary<BattleRole, UnitPresenter>());

                _unitsDictionary[unit.Faction].Add(unit.BattleRole, unit);
            }
        }

        public void CreateUnit(UnitSetup setup)
        {
            Unit unit = new Unit(
                setup,
                _enemyBase);

            CreatePresenter(_unitsDictionary[setup.Faction][setup.BattleRole], unit);
            unit.MoveTo(GenerateSpawnPosition());
        }

        private Presenter CreatePresenter(Presenter presenterTemplate, Transformable model)
        {
            Presenter presenter = Instantiate(presenterTemplate);
            presenter.Init(model);
            return presenter;
        }

        private Vector3 GenerateSpawnPosition()
        {
            int randomPositionZ = Random.Range(_minSpawnPositionZ, _maxSpawnPositionZ);

            while (_previousSpawnPosition == randomPositionZ)
                randomPositionZ = Random.Range(_minSpawnPositionZ, _maxSpawnPositionZ);

            _previousSpawnPosition = randomPositionZ;

            return new Vector3(_spawnPoint.position.x, _spawnPoint.position.y, randomPositionZ);
        }
    }
}
