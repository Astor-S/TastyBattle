using System.Collections.Generic;
using UnityEngine;
using StructureElements;
using Units.Interfaces;

namespace Units
{
    public abstract class UnitFactory : MonoBehaviour, IUnitFactory
    {
        private readonly int _minSpawnPositionZ = -5;
        private readonly int _maxSpawnPositionZ = 5;

        [SerializeField] private DamagableTarget _enemyBase;
        [SerializeField] private Transform _spawnPoint;

        protected Dictionary<BattleRole, UnitPresenter> _unitTemplates;
        private int _previousSpawnPosition = 0;

        public void CreateUnit(UnitSetup setup, int layerNumber)
        {
            if (_unitTemplates.ContainsKey(setup.BattleRole) == false)
            {
                Debug.LogError($"UnitTemplate not found for BattleRole: {setup.BattleRole} in faction: {setup.Faction}");
                return;
            }

            UnitPresenter unit = CreatePresenter(
                _unitTemplates[setup.BattleRole],
                new Unit(setup)) as UnitPresenter;

            unit.gameObject.layer = layerNumber;

            int randomPositionZ = Random.Range(_minSpawnPositionZ, _maxSpawnPositionZ);
            
            while (_previousSpawnPosition == randomPositionZ)
                randomPositionZ = Random.Range(_minSpawnPositionZ, _maxSpawnPositionZ);

            unit.transform.position = new Vector3(_spawnPoint.position.x, _spawnPoint.position.y, randomPositionZ);
            _previousSpawnPosition = randomPositionZ;

            unit.gameObject.SetActive(true);

            IActivatable abilityHandler = CreateAbilityHandler(setup); 

            if (unit is IUnitWithAbility unitWithAbility)
                unitWithAbility.SetAbility(abilityHandler);
            
            unit.UnitMovementInput.SetInitialTarget(_enemyBase.transform);
            unit.DetectionSystem.SetInitialTarget(_enemyBase.transform);
        }

        protected abstract IActivatable CreateAbilityHandler(UnitSetup unitSetup);

        protected virtual Presenter CreatePresenter(Presenter presenterTemplate, Transformable model)
        {
            Presenter presenter = Instantiate(presenterTemplate);
            presenter.Init(model);
            
            return presenter;
        }
    }
}
