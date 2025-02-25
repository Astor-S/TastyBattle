using StructureElements;
using System;
using Units;

namespace ResourceDistribution
{
    public class Shop : Transformable, IActivatable
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
                item.UnitOrdered += SpawUnit;
        }

        public void Disable()
        {
            foreach (UnitUIItem item in _unitItems)
                item.UnitOrdered -= SpawUnit;
        }

        private void SpawUnit(Faction faction, BattleRole battleRole, int cost)
        {
            try
            {
                _wallet.SpendResource(cost);
                _unitFactory.CreateUnit(
                    faction,
                    battleRole,
                    _unitFactory.gameObject.layer,
                    _unitFactory.transform.position);

                UnityEngine.Debug.Log($"Account balance: {_wallet.ResourceCount} (-{cost})");
            }
            catch (InvalidOperationException exc)
            {
                UnityEngine.Debug.Log(exc.Message + ": " + faction.ToString() + ", " + battleRole.ToString());
            }
        }
    }
}
