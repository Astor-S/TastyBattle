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
            int layerNumber,
            float unitSpawnCooldown,
            int unitSpawnCount,
            UnitFactory unitFactory)
            : base (position)
        {
            Spawner = new Spawner(
                layerNumber,
                unitSpawnCooldown,
                unitSpawnCount,
                unitFactory,
                position);
        }
    }
}