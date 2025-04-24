using UnityEngine;

public class UpgradeOrderHandler : OrderHandler
{
    [SerializeField] private UpgradeType _upgradeType;

    protected override Order InitializeOrder(int initialCost)
    {
        return new UpgradeOrder(initialCost, _upgradeType);
    }
}
