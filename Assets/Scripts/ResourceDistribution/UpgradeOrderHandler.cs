using TMPro;
using UnityEngine;
using Upgrades;
using YG;

namespace ResourceDistribution
{
    public class UpgradeOrderHandler : OrderHandler
    {
        [SerializeField] private UpgradeType _upgradeType;
        [SerializeField, Range(2, 10)] private int _maxLevel;
        [SerializeField] private TextMeshProUGUI _levelNumberBox;
        [SerializeField] private TextMeshProUGUI _levelTextBox;
        [SerializeField] private TextMeshProUGUI _maxLevelBox;

        protected new UpgradeOrder Order => base.Order as UpgradeOrder;

        protected override Order InitializeOrder(int initialCost)
        {
            return new UpgradeOrder(initialCost, _maxLevel, _upgradeType);
        }

        protected override void OnOrdered()
        {
            if (_levelNumberBox != null)
                YG2.MetricaSend("upgrade_ordered");

            Order.IncreaseCost();
            Order.IncreaseLevel();

            if (_levelNumberBox != null)
            {
                if (Order.CurrentLevel == Order.MaxLevel)
                {
                    _maxLevelBox.gameObject.SetActive(true);
                    _levelTextBox.gameObject.SetActive(false);
                    _levelNumberBox.gameObject.SetActive(false);
                }
                else
                {
                    _levelNumberBox.text = Order.CurrentLevel.ToString();
                }
            }
        }
    }
}
