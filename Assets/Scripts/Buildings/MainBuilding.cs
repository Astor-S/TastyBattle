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
            Quaternion rotation,
            int layerNumber,
            float unitSpawnCooldown,
            int unitSpawnCount,
            UnitFactory unitFactory)
            : base(position, rotation)
        {
            Spawner = new Spawner(
                layerNumber,
                unitSpawnCooldown,
                unitSpawnCount,
                unitFactory);
        }
    }
}