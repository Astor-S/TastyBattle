using UnityEngine;

public class UpgradeOrderHandler : OrderHandler
{
    [SerializeField] private UpgradeType _upgradeType;

    protected override Order InitializeOrder()
    {
        return new UpgradeOrder(_upgradeType);
    }
}
