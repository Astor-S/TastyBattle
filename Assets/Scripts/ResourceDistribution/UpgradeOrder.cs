public class UpgradeOrder : Order
{
    public UpgradeType Type { get; }
    public int MaxLevel { get; }
    public int CurrentLevel { get; private set; }

    public UpgradeOrder(int cost, int maxLevel, UpgradeType upgradeType) : base(cost)
    {
        Type = upgradeType;
        MaxLevel = maxLevel;
        CurrentLevel = 1;
    }

    public void IncreaseLevel()
    {
        if (++CurrentLevel == MaxLevel)
            SetUnavailable();
    }
}
