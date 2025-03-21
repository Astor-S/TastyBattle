using System.Collections;
using UnityEngine;

namespace Units
{
    public class Spawner
    {
        private float _spawnTimeBetweenUnits = 0.7f;
        private float _defaultSpawnCooldown;
        private int _spawnCount;
        private UnitFactory _unitFactory;
        private UnitSetup[] _unitSetups;
        private bool _isGameRunning = true;

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
        }

        public IEnumerator GetSpawningCoroutine()
        {
            WaitForSeconds cooldownWaiting = new WaitForSeconds(_defaultSpawnCooldown);
            WaitForSeconds timeBetweenUnits = new WaitForSeconds(_spawnTimeBetweenUnits);

            while (_isGameRunning)
            {
                yield return cooldownWaiting;

                for (int i = 0; i < _spawnCount; i++)
                {
                    _unitFactory.CreateUnit(_unitSetups[0]);

                    yield return timeBetweenUnits;
                }
            }
        }
    }
}