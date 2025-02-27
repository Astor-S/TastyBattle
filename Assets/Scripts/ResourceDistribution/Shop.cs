using StructureElements;
using System;
using Units;

namespace ResourceDistribution
{
    public class Shop : IActivatable
    {
        private UnitFactory _unitFactory;
        private UnitUIItem[] _unitItems;
        private Wallet _wallet;

        public Shop(UnitFactory unitFactory, UnitUIItem[] unitItems, Wallet wallet)
        {
            _unitFactory = unitFactory;
            _unitItems = unitItems;
            _wallet = wallet;
        }

        public void Enable()
        {
            foreach (UnitUIItem item in _unitItems)
                item.UnitOrdered += SpawnUnit;
        }

        public void Disable()
        {
            foreach (UnitUIItem item in _unitItems)
                item.UnitOrdered -= SpawnUnit;
        }

        private void SpawnUnit(Faction faction, BattleRole battleRole, int cost)
        {
            try
            {
                _wallet.SpendResource(cost);
                _unitFactory.CreateUnit(
                    faction,
                    battleRole,
                    _unitFactory.gameObject.layer);

                UnityEngine.Debug.Log($"Account balance: {_wallet.ResourceCount} (-{cost})");
            }
            catch (InvalidOperationException exc)
            {
                UnityEngine.Debug.Log(exc.Message + ": " + faction.ToString() + ", " + battleRole.ToString());
            }
        }
    }
}
