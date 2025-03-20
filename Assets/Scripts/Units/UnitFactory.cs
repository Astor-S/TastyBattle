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

            UnitPresenter presenter = CreatePresenter(_unitTemplates[setup.BattleRole]) as UnitPresenter;
            Unit model = new Unit(setup, presenter.GetComponent<DetectionSystem>(), presenter.GetComponent<Health>());

            presenter.Init(model);
            presenter.gameObject.layer = layerNumber;

            int randomPositionZ = Random.Range(_minSpawnPositionZ, _maxSpawnPositionZ);
            
            while (_previousSpawnPosition == randomPositionZ)
                randomPositionZ = Random.Range(_minSpawnPositionZ, _maxSpawnPositionZ);

            presenter.transform.position = new Vector3(_spawnPoint.position.x, _spawnPoint.position.y, randomPositionZ);
            _previousSpawnPosition = randomPositionZ;

            presenter.gameObject.SetActive(true);

            AbilityHandler abilityHandler = CreateAbilityHandler(setup); 

            if (model is IUnitWithAbility unitWithAbility)
                unitWithAbility.SetAbility(abilityHandler);
            
            presenter.UnitMovementInput.SetInitialTarget(_enemyBase.transform);
            presenter.DetectionSystem.SetInitialTarget(_enemyBase.transform);
        }

        protected abstract AbilityHandler CreateAbilityHandler(UnitSetup unitSetup);

        protected virtual Presenter CreatePresenter(Presenter presenterTemplate)
        {
            Presenter presenter = Instantiate(presenterTemplate);
            
            return presenter;
        }
    }
}
