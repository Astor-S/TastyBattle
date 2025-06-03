using UnityEngine;
using GameService.GameHandlerSystem.Counters;
using Units;

namespace GameService.GameHandlerSystem.Handlers
{
    public class UnitDeatTracker : MonoBehaviour
    {
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

            if ((_enemyLayer.value & (1 << unitLayer)) != 0)
                unitPresenter.OnUnitDying += OnUnitDying;          
        }

        private void OnUnitDying(UnitPresenter unitPresenter)
        {
            if (_killedEnemyCounter != null)
            {
                unitPresenter.OnUnitDying -= OnUnitDying;
                _killedEnemyCounter.EnemyKilled(); 
            }    
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
        }
    }
}