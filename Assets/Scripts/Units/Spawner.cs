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
        private Vector3 _unitPositionOnSpawn;
        private Quaternion _unitRotationOnSpawn;
        private bool _isGameRunning = true;

        public Spawner(
            float defaultSpawnCooldown,
            int spawnCount,
            UnitFactory unitFactory,
            Vector3 unitPositionOnSpawn,
            Quaternion unitRotationOnSpawn)
        {
            _defaultSpawnCooldown = defaultSpawnCooldown;
            _spawnCount = spawnCount;
            _unitFactory = unitFactory;
            _unitPositionOnSpawn = unitPositionOnSpawn;
            _unitRotationOnSpawn = unitRotationOnSpawn;
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
                    _unitFactory.CreateUnit(
                        Faction.Mushroom,
                        BattleRole.Melee,
                        _unitPositionOnSpawn,
                        _unitRotationOnSpawn);

                    yield return timeBetweenUnits;
                }
            }
        }
    }
}