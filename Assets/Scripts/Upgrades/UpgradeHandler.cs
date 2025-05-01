public class UpgradeHandler
{
    private const float UpgradeValue = 0.2f;

    private UpgradeSetup _upgradeSetup;

    public UpgradeHandler(UpgradeSetup upgradeSetup) =>
        _upgradeSetup = upgradeSetup;

    public float GetIncreasedDamage(AttackerSetup attackerSetup) => 
        attackerSetup.AttackDamage * UpgradeValue * _upgradeSetup.UnitDamageUpgrade;

    public float GetIncreasedSpeed(UnitSetup unitSetup) => 
        unitSetup.MovementSpeed * UpgradeValue * _upgradeSetup.UnitSpeedUpgrade;

    public float GetIncreasedHealth(DamagableSetup damagableSetup) =>
        damagableSetup.MaxHealthPoints * UpgradeValue * _upgradeSetup.UnitHealthUpgrade;

    //TODO
    public void IncreaseBuldingHealth()
    {
        UnityEngine.Debug.Log("Buildings' health has been increased by ???%");
    }

    public float GetIncreasedIncome(Mine mine) => 
        mine.IncomeValue * UpgradeValue * _upgradeSetup.IncomeUpgrade;
}
