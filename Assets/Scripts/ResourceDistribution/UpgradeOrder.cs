public class UpgradeOrder : Order
{
    public UpgradeType Type { get; }

    public UpgradeOrder(UpgradeType upgradeType)
    {
        Type = upgradeType;
    }
}
