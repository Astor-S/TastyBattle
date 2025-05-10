using StructureElements;
using System;
using Units;
using UnityEngine;

namespace ResourceDistribution
{
    public class Shop : Transformable, IActivatable
    {
        private UnitFactory _unitFactory;
        private UnitOrderHandler[] _unitItems;
        private UpgradeOrderHandler[] _upgradeItems;
        private Wallet _wallet;
        private UpgradesData _upgradeData;

        public Shop(
            UnitFactory unitFactory,
            UnitOrderHandler[] unitItems,
            UpgradeOrderHandler[] upgradeItems,
            Wallet wallet)
        {
            _unitFactory = unitFactory;
            _unitItems = unitItems;
            _upgradeItems = upgradeItems;
            _wallet = wallet;
            
            _upgradeData = _unitFactory.gameObject.layer == LayerMask.NameToLayer("Player") ?
                Upgrades.Player :
                Upgrades.Enemy;
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
                        _upgradeData.IncreaseUnitDamage();
                        break;

                    case UpgradeType.UnitHealthIncrease:
                        _upgradeData.IncreaseUnitHealth();
                        break;

                    case UpgradeType.UnitSpeedIncrease:
                        _upgradeData.IncreaseUnitSpeed();
                        break;

                    case UpgradeType.BuildingHealthIncrease:
                        _upgradeData.IncreaseBuildingHealth();
                        break;

                    case UpgradeType.IncomeIncrease:
                        _upgradeData.IncreaseMineIncome();
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
