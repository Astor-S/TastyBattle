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
        private UpgradeSetup _upgradeSetup;
        private Wallet _wallet;

        public Shop(
            UnitFactory unitFactory,
            UnitOrderHandler[] unitItems,
            UpgradeOrderHandler[] upgradeItems,
            UpgradeSetup upgradeSetup,
            Wallet wallet)
        {
            _unitFactory = unitFactory;
            _unitItems = unitItems;
            _upgradeItems = upgradeItems;
            _upgradeSetup = upgradeSetup;
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

        private void SpawnUnit(Order order)
        {
            UnitOrder unit = order as UnitOrder;

            try
            {
                _wallet.SpendResource(unit.Cost);
                _unitFactory.CreateUnit(unit.Setup);
            }
            catch (InvalidOperationException exc)
            {
                throw new InvalidOperationException(exc.Message + ": " + unit.Setup.BattleRole.ToString() + " " + unit.Setup.Faction.ToString());
            }
        }

        private void MakeUpgrade(Order order)
        {
            UpgradeOrder upgrade = order as UpgradeOrder;

            try
            {
                _wallet.SpendResource(upgrade.Cost);

                switch (upgrade.Type)
                {
                    case UpgradeType.UnitDamageIncrease:
                        _upgradeSetup.IncreaseUnitDamage();
                        break;

                    case UpgradeType.UnitHealthIncrease:
                        _upgradeSetup.IncreaseUnitHealth();
                        break;

                    case UpgradeType.UnitSpeedIncrease:
                        _upgradeSetup.IncreaseUnitSpeed();
                        break;

                    case UpgradeType.BuildingHealthIncrease:
                        _upgradeSetup.IncreaseBuildingHealth();
                        break;

                    case UpgradeType.IncomeIncrease:
                        _upgradeSetup.IncreaseMineIncome();
                        break;
                }
            }
            catch (InvalidOperationException exc)
            {
                throw new InvalidOperationException(exc.Message + ": " + upgrade.Type.ToString() + " " + upgrade.Cost.ToString());
            }
        }
    }
}
