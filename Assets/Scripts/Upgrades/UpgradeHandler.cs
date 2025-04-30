using UnityEngine;

public class UpgradeHandler : MonoBehaviour
{
    [SerializeField] private UpgradeSetup _upgradeSetup;

    private float _upgradeValue = 0.2f;

    //public UpgradeHandler(UpgradeSetup upgradeSetup) => 
    //    _upgradeSetup = upgradeSetup;

    public float GetIncreasedDamage(AttackerSetup attackerSetup) => 
        attackerSetup.AttackDamage * _upgradeValue * _upgradeSetup.UnitSpeedUpgrade;

    public float GetIncreasedSpeed(UnitSetup unitSetup) => 
        unitSetup.MovementSpeed * _upgradeValue * _upgradeSetup.UnitSpeedUpgrade;

    public float GetIncreasedHealth(DamagableSetup damagableSetup) =>
        damagableSetup.MaxHealthPoints * _upgradeValue * _upgradeSetup.UnitHealthUpgrade;

    //TODO
    public void IncreaseBuldingHealth()
    {
        UnityEngine.Debug.Log("Buildings' health has been increased by ???%");
    }

    public float GetIncreasedIncome(Mine mine) => 
        mine.IncomeValue * _upgradeValue * _upgradeSetup.IncomeUpgrade;
}
