using StructureElements;
using Units;
using UnityEngine;

namespace Buildings
{
    public class MainBuilding : Transformable
    {
        public Spawner Spawner { get; }

        public MainBuilding(
            Vector3 position,
            Vector3 scale,
            float unitSpawnCooldown,
            int unitSpawnCount,
            UnitFactory unitFactory,
            Vector3 unitPositionOnSpawn,
            Quaternion unitRotationOnSpawn)
            : base (position: position, scale: scale)
        {
            Spawner = new Spawner(
                unitSpawnCooldown,
                unitSpawnCount,
                unitFactory,
                unitPositionOnSpawn,
                unitRotationOnSpawn);
        }
    }
}