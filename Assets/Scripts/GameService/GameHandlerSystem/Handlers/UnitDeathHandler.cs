using System.Collections.Generic;
using UnityEngine;
using GameService.GameHandlerSystem.Counters;
using Units;

namespace GameService.GameHandlerSystem.Handlers
{
    public class UnitDeathHandler : MonoBehaviour
    {
        private readonly HashSet<UnitPresenter> _subscribedUnits = new();

        [SerializeField] private KilledEnemyCounter _killedEnemyCounter;
        [SerializeField] private LayerMask _enemyLayer;

        public void OnUnitSpawned(UnitPresenter unitPresenter)
        {
            if (unitPresenter != null)
                SubscribeToUnit(unitPresenter);
        }

        private void SubscribeToUnit(UnitPresenter unitPresenter)
        {
            int unitLayer = unitPresenter.gameObject.layer;

            if ((_enemyLayer.value & (1 << unitLayer)) != 0 && !_subscribedUnits.Contains(unitPresenter))
            {
                unitPresenter.OnUnitDying += OnUnitDying;
                _subscribedUnits.Add(unitPresenter); 
            }
        }

        private void OnUnitDying()
        {
            if (_killedEnemyCounter != null)
                _killedEnemyCounter.EnemyKilled(); 
        }

        private void OnDestroy()
        {
            UnitPresenter[] presenters = FindObjectsOfType<UnitPresenter>();

            foreach (UnitPresenter presenter in presenters)
            {
                int unitLayer = presenter.gameObject.layer;

                if ((_enemyLayer.value & (1 << unitLayer)) != 0)
                    presenter.OnUnitDying -= OnUnitDying;
            }

            _subscribedUnits.Clear();
        }
    }
}