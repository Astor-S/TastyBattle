using ResourceDistribution;
using StructureElements;
using Units;
using UnityEngine;

namespace Buildings
{
    public class MainBuilding : Transformable, IActivatable
    {
        private Shop _shop;
        private Wallet _wallet;

        public Spawner Spawner { get; }

        public MainBuilding(
            Vector3 position,
            Vector3 scale,
            int layerNumber,
            float unitSpawnCooldown,
            int unitSpawnCount,
            UnitFactory unitFactory,
            UnitUIItem[] unitItems,
            Wallet wallet)
            : base (position: position, scale: scale)
        {
            Spawner = new Spawner(
                layerNumber,
                unitSpawnCooldown,
                unitSpawnCount,
                unitFactory,
                position);

            _wallet = wallet;
            _shop = new Shop(unitFactory, unitItems, _wallet);
        }

        public void Enable()
        {
            _shop.Enable();
            _wallet.Enable();
        }

        public void Disable()
        {
            _shop.Disable();
            _wallet.Disable();
        }
    }
}