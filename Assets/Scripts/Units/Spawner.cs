using System;
using System.Collections;
using UnityEngine;

namespace Units
{
    public class Spawner
    {
        private float _spawnTimeBetweenUnits = 0.6f;
        private float _defaultSpawnCooldown;
        private int _spawnCount;
        private UnitFactory _unitFactory;
        private UnitSetup[] _unitSetups;
        private bool _isGameRunning = true;
        private WaitForSeconds _delay;

        public event Action OnSpawn;

        public Spawner(
            float defaultSpawnCooldown,
            int spawnCount,
            UnitFactory unitFactory,
            UnitSetup[] unitSetups)
        {
            _defaultSpawnCooldown = defaultSpawnCooldown;
            _spawnCount = spawnCount;
            _unitFactory = unitFactory;
            _unitSetups = unitSetups;
            _delay = new WaitForSeconds(_spawnTimeBetweenUnits);
        }

        public IEnumerator GetSpawningCoroutine()
        {
            WaitForSeconds cooldownWaiting = new WaitForSeconds(_defaultSpawnCooldown);            

            while (_isGameRunning)
            {
                yield return cooldownWaiting;

                OnSpawn?.Invoke();
            }
        }

        public IEnumerator DelayedSpawn()
        {
            for (int i = 0; i < _spawnCount; i++)
            {
                _unitFactory.CreateUnit(_unitSetups[0]);

                yield return _delay;
            }
        }
    }
}