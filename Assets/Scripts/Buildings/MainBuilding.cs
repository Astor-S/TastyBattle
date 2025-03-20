using Units;
using UnityEngine;

namespace Buildings
{
    public class MainBuilding : Building
    {
        public Spawner Spawner { get; }

        public MainBuilding(
            
            DamagableSetup setup,
            int layerNumber,
            float unitSpawnCooldown,
            int unitSpawnCount,
            UnitFactory unitFactory,
            UnitSetup[] unitSetups,
            Vector3 position,
            Quaternion rotation)
            : base(setup, position, rotation)
        {
            Spawner = new Spawner(
                layerNumber,
                unitSpawnCooldown,
                unitSpawnCount,
                unitFactory,
                unitSetups);
        }
    }
}