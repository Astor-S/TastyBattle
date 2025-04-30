using UnityEngine;

[CreateAssetMenu(fileName = "UpgradeSetup", menuName = "Scriptable Objects/Upgrade")]
public class UpgradeSetup : ScriptableObject
{
    public int UnitHealthUpgrade {  get; private set; } = 0;
    public int UnitDamageUpgrade { get; private set; } = 0;
    public int UnitSpeedUpgrade { get; private set; } = 0;
    public int BuildingsHealthUpgrade { get; private set; } = 0;
    public int IncomeUpgrade { get; private set; } = 0;

    public void ResetValues()
    {
        UnitHealthUpgrade = 0;
        UnitDamageUpgrade = 0;
        UnitSpeedUpgrade = 0;
        BuildingsHealthUpgrade = 0;
        IncomeUpgrade = 0;
    }

    public void IncreaseUnitHealth() => UnitHealthUpgrade++;
    public void IncreaseUnitDamage() => UnitDamageUpgrade++;
    public void IncreaseUnitSpeed() => UnitSpeedUpgrade++;
    public void IncreaseBuildingHealth() => BuildingsHealthUpgrade++;
    public void IncreaseMineIncome() => IncomeUpgrade++;
}
