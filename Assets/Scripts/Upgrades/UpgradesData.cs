using System;
using UnityEngine;

[System.Serializable]
public class UpgradesData
{
    [SerializeField] private float _damageUpgradeMultiplier = 1.2f;
    [SerializeField] private float _speedUpgradeMultiplier = 1.2f;
    [SerializeField] private float _unitHealthUpgradeMultiplier = 1.2f;
    [SerializeField] private float _buildingHealthUpgradeMultiplier = 1.2f;
    [SerializeField] private float _incomeUpgradeMultiplier = 1.2f;

    public int UnitDamageUpgradeValue { get; private set; }
    public int UnitSpeedUpgradeValue { get; private set; }
    public int UnitHealthUpgradeValue { get; private set; }
    public int BuildingsHealthUpgradeValue { get; private set; }
    public int IncomeUpgradeValue { get; private set; }

    public event Action BuildingHealthUpgraded;
    public event Action UnitHealthUpgraded;

    public void IncreaseUnitDamage()
    {
        ++UnitDamageUpgradeValue;
    }

    public void IncreaseUnitSpeed()
    {
        ++UnitSpeedUpgradeValue;
    }

    public void IncreaseUnitHealth()
    {
        ++UnitHealthUpgradeValue;
        UnitHealthUpgraded?.Invoke();
    }

    public void IncreaseBuildingHealth()
    {
        ++BuildingsHealthUpgradeValue;
        BuildingHealthUpgraded?.Invoke();
    }

    public void IncreaseMineIncome()
    {
        ++IncomeUpgradeValue;
    }

    public float GetIncreasedDamage(AttackerSetup attackerSetup) =>
        attackerSetup.AttackDamage * Mathf.Pow(_damageUpgradeMultiplier, UnitDamageUpgradeValue);

    public float GetIncreasedSpeed(UnitSetup unitSetup) =>
        unitSetup.MovementSpeed * Mathf.Pow(_speedUpgradeMultiplier, UnitSpeedUpgradeValue);

    public float GetIncreasedUnitHealth(DamagableSetup damagableSetup) =>
        damagableSetup.MaxHealthPoints * Mathf.Pow(_unitHealthUpgradeMultiplier, UnitHealthUpgradeValue);

    public float GetIncreasedBuldingHealth(DamagableSetup damagableSetup) =>
        damagableSetup.MaxHealthPoints * Mathf.Pow(_buildingHealthUpgradeMultiplier, BuildingsHealthUpgradeValue);

    public int GetIncreasedIncome(Mine mine) =>
        (int)(mine.IncomeValue * Mathf.Pow(_incomeUpgradeMultiplier, IncomeUpgradeValue));
}