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
            int layerNumber,
            float unitSpawnCooldown,
            int unitSpawnCount,
            UnitFactory unitFactory)
            : base (position: position, scale: scale)
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