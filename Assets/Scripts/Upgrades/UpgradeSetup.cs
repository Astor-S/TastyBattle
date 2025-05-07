using UnityEngine;

[CreateAssetMenu(fileName = "UpgradeSetup", menuName = "Scriptable Objects/Upgrade")]
public class UpgradeSetup : ScriptableObject
{
    public int UnitHealthUpgrade {  get; private set; }
    public int UnitDamageUpgrade { get; private set; }
    public int UnitSpeedUpgrade { get; private set; }
    public int BuildingsHealthUpgrade { get; private set; }
    public int IncomeUpgrade { get; private set; }

    public void ResetValues()
    {
        UnitHealthUpgrade = default;
        UnitDamageUpgrade = default;
        UnitSpeedUpgrade = default;
        BuildingsHealthUpgrade = default;
        IncomeUpgrade = default;
    }

    public void IncreaseUnitHealth() =>
        ++UnitHealthUpgrade;

    public void IncreaseUnitDamage() =>
        ++UnitDamageUpgrade;

    public void IncreaseUnitSpeed() =>
        ++UnitSpeedUpgrade;

    public void IncreaseBuildingHealth() =>
        ++BuildingsHealthUpgrade;

    public void IncreaseMineIncome() =>
        ++IncomeUpgrade;
}
