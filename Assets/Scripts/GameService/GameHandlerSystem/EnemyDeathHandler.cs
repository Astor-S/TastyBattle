using UnityEngine;
using AttackSystem;
using AttackSystem.Interfaces;
using Units;

namespace GameService.GameHandlerSystem
{
    public class EnemyDeathHandler : MonoBehaviour
    {
        [SerializeField] private KilledEnemyCounter _killedEnemyCounter;
        [SerializeField] private DamagableTarget _damagableTarget;
        [SerializeField] private LayerMask _enemyLayer;

        private void OnEnable()
        {
            if (_damagableTarget == null)
            {
                _damagableTarget = GetComponent<DamagableTarget>();
                
                if (_damagableTarget == null)
                {
                    Debug.LogError("DamagableTarget не найден на этом объекте: " + gameObject.name);
                    enabled = false;
                    return;
                }
            }

            _damagableTarget.Dying += OnDying;
        }

        private void OnDisable()
        {
            if (_damagableTarget != null)
            {
                _damagableTarget.Dying -= OnDying;
            }
        }

        private void OnDying(IDamagable damagable)
        {
            if (_killedEnemyCounter != null && damagable is Unit && _damagableTarget.gameObject.layer == _enemyLayer)
                _killedEnemyCounter.EnemyKilled();
        }
    }
}