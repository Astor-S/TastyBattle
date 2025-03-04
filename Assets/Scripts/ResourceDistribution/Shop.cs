using StructureElements;
using System;
using Units;

namespace ResourceDistribution
{
    public class Shop : Transformable, IActivatable
    {
        private UnitFactory _unitFactory;
        private UnitOrderHandler[] _unitItems;
        private UpgradeOrderHandler[] _upgradeItems;
        private UpgradeHandler _upgradeHandler;
        private Wallet _wallet;

        public Shop(
            UnitFactory unitFactory,
            UnitOrderHandler[] unitItems,
            UpgradeOrderHandler[] upgradeItems,
            UpgradeHandler upgradeHandler,
            Wallet wallet)
        {
            _unitFactory = unitFactory;
            _unitItems = unitItems;
            _upgradeItems = upgradeItems;
            _upgradeHandler = upgradeHandler;
            _wallet = wallet;
        }

        public void Enable()
        {
            foreach (UnitOrderHandler item in _unitItems)
                item.ItemOrdered += SpawnUnit;

            foreach (UpgradeOrderHandler item in _upgradeItems)
                item.ItemOrdered += MakeUpgrade;

            _wallet.Enable();
        }

        public void Disable()
        {
            foreach (UnitOrderHandler item in _unitItems)
                item.ItemOrdered -= SpawnUnit;

            foreach (UpgradeOrderHandler item in _upgradeItems)
                item.ItemOrdered -= MakeUpgrade;

            _wallet.Disable();
        }

        private void SpawnUnit(Order order, int cost)
        {
            UnitOrder unit = order as UnitOrder;

            try
            {
                _wallet.SpendResource(cost);
                _unitFactory.CreateUnit(unit.Setup, _unitFactory.gameObject.layer);

                UnityEngine.Debug.Log($"Account balance: {_wallet.ResourceCount} (-{cost})");
            }
            catch (InvalidOperationException exc)
            {
                UnityEngine.Debug.Log(exc.Message + ": " + unit.Setup.Faction.ToString() + ", " + unit.Setup.BattleRole.ToString());
            }
        }

        private void MakeUpgrade(Order order, int cost)
        {
            UpgradeOrder upgrade = order as UpgradeOrder;

            try
            {
                _wallet.SpendResource(cost);

                switch (upgrade.Type)
                {
                    case UpgradeType.UnitDamageIncrease:
                        _upgradeHandler.IncreaseUnitDamage();
                        break;

                    case UpgradeType.UnitHealthIncrease:
                        _upgradeHandler.IncreaseUnitHealth();
                        break;

                    case UpgradeType.BuildingHealthIncrease:
                        _upgradeHandler.IncreaseBuldingHealth();
                        break;
                }
            }
            catch (InvalidOperationException exc)
            {
                UnityEngine.Debug.Log(exc.Message + ": " + upgrade.Type.ToString());
            }
        }
    }
}
