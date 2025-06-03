using System.Collections.Generic;
using UnityEngine;
using AttackSystem;
using GameService.GameHandlerSystem.Handlers;
using Pools;

namespace Units
{
    public class UnitFactory : MonoBehaviour
    {
        private const int MinSpawnPositionZ = -5;
        private const int MaxSpawnPositionZ = 5;

        [SerializeField] private FactionUnits _factionUnits;
        [SerializeField] private DamagableTarget _enemyBase;
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private UnitDeatTracker _enemyDeathHandler;

        private int _previousSpawnPosition = 0;
        private Dictionary<BattleRole, MVPPool<UnitPresenter, Unit>> _pools;

        private void Awake()
        {
            _pools = new Dictionary<BattleRole, MVPPool<UnitPresenter, Unit>>()
            {
                {
                    BattleRole.Melee,
                    new MVPPool<UnitPresenter, Unit>(
                        (model) => CreatePresenter(model),
                        (unit) => unit.gameObject.SetActive(false))
                },
                {
                    BattleRole.Range,
                    new MVPPool<UnitPresenter, Unit>(
                        (model) => CreatePresenter(model),
                        (unit) => unit.gameObject.SetActive(false))
                },
                {
                    BattleRole.Tank,
                    new MVPPool<UnitPresenter, Unit>(
                        (model) => CreatePresenter(model),
                        (unit) => unit.gameObject.SetActive(false))
                },
                {
                    BattleRole.Siege,
                    new MVPPool<UnitPresenter, Unit>(
                        (model) => CreatePresenter(model),
                        (unit) => unit.gameObject.SetActive(false))
                },
            };
        }

        public void CreateUnit(UnitSetup setup)
        {
            Unit unit;

            if (setup is WatermellonSiegeSetup)
                unit = new WatermellonSiege(setup, _enemyBase);
            else
                unit = new Unit(setup, _enemyBase);

            UnitPresenter presenter = _pools[setup.BattleRole].GetObject(unit);
            presenter.transform.position = GenerateSpawnPosition();
            presenter.gameObject.SetActive(true);
            presenter.Releasing += ReleaseIntoPool;

            _enemyDeathHandler.OnUnitSpawned(presenter);
        }

        private UnitPresenter CreatePresenter(Unit model)
        {
            UnitPresenter presenter = Instantiate(_factionUnits.Dictionary[model.BattleRole]);
            presenter.Init(model);
            return presenter;
        }

        private Vector3 GenerateSpawnPosition()
        {
            int randomPositionZ = Random.Range(MinSpawnPositionZ, MaxSpawnPositionZ);

            while (_previousSpawnPosition == randomPositionZ)
                randomPositionZ = Random.Range(MinSpawnPositionZ, MaxSpawnPositionZ);

            _previousSpawnPosition = randomPositionZ;

            return new Vector3(_spawnPoint.position.x, _spawnPoint.position.y, randomPositionZ);
        }

        private void ReleaseIntoPool(UnitPresenter unitPresenter)
        {
            unitPresenter.Releasing -= ReleaseIntoPool;

            _pools[unitPresenter.Model.BattleRole].Release(unitPresenter);
        }
    }
}
