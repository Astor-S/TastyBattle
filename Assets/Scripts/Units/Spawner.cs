using System;
using System.Collections;
using UnityEngine;

namespace Units
{
    public class Spawner
    {
        private readonly float _spawnTimeBetweenUnits = 0.6f;
        private readonly float _defaultSpawnCooldown;
        private readonly int _spawnCount;
        private readonly UnitFactory _unitFactory;
        private readonly UnitSetup[] _unitSetups;
        private readonly bool _isGameRunning = true;
        private readonly WaitForSeconds _delay;

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

        public event Action OnSpawn;

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