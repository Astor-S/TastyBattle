public class UpgradeOrder : Order
{
    public UpgradeType Type { get; }

    public UpgradeOrder(int cost, UpgradeType upgradeType) : base(cost)
    {
        Type = upgradeType;
    }
}
