using ResourceDistribution;
using Units;
using UnityEngine;

namespace Buildings
{
    public class MainBuilding : Building
    {
        public Spawner Spawner { get; }
        public Wallet Wallet { get; }

        public MainBuilding(
            
            DamagableSetup setup,
            float unitSpawnCooldown,
            int unitSpawnCount,
            UnitFactory unitFactory,
            UnitSetup[] unitSetups,
            Wallet wallet,
            Vector3 position,
            Quaternion rotation)
            : base(setup, position, rotation)
        {
            Spawner = new Spawner(
                unitSpawnCooldown,
                unitSpawnCount,
                unitFactory,
                unitSetups);

            Wallet = wallet;
        }
    }
}