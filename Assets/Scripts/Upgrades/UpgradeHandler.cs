using UnityEngine;

public class UpgradeHandler
{
    private const float UpgradeValue = 1.2f;

    private UpgradeSetup _upgradeSetup;

    public UpgradeHandler(UpgradeSetup upgradeSetup) =>
        _upgradeSetup = upgradeSetup;

    public float GetIncreasedDamage(AttackerSetup attackerSetup) => 
        attackerSetup.AttackDamage * Mathf.Pow(UpgradeValue, _upgradeSetup.UnitDamageUpgrade);

    public float GetIncreasedSpeed(UnitSetup unitSetup) => 
        unitSetup.MovementSpeed * Mathf.Pow(UpgradeValue, _upgradeSetup.UnitSpeedUpgrade);

    public float GetIncreasedHealth(DamagableSetup damagableSetup) =>
        damagableSetup.MaxHealthPoints * Mathf.Pow(UpgradeValue, _upgradeSetup.UnitHealthUpgrade);

    public float GetIncreasedBuldingHealth(DamagableSetup damagableSetup) =>
        damagableSetup.MaxHealthPoints * Mathf.Pow(UpgradeValue, _upgradeSetup.BuildingsHealthUpgrade);

    public int GetIncreasedIncome(Mine mine) => 
        (int)(mine.IncomeValue * Mathf.Pow(UpgradeValue, _upgradeSetup.IncomeUpgrade));
}
