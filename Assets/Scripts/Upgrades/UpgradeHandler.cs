public class UpgradeHandler
{
    private UnitSetup[] _unitSetups;
    private float _defaultDamageBoostPortion = 0.2f;
    private float _defaultHealthBoostPortion = 0.2f;

    public UpgradeHandler(UnitSetup[] unitSetups)
    {
        _unitSetups = unitSetups; 
    }

    public void IncreaseUnitDamage()
    {
        foreach (UnitSetup unitSetup in _unitSetups)
            unitSetup.IncreaseDamage(_defaultDamageBoostPortion);

        UnityEngine.Debug.Log("Units' damage has been increased by " + _defaultDamageBoostPortion * 100 + "%");
    }

    public void IncreaseUnitHealth()
    {
        foreach (UnitSetup unitSetup in _unitSetups)
            unitSetup.IncreaseHealth(_defaultHealthBoostPortion);

        UnityEngine.Debug.Log("Units' health has been increased by " + _defaultHealthBoostPortion * 100 + "%");
    }

    public void IncreaseBuldingHealth()
    {
        UnityEngine.Debug.Log("Buildings' health has been increased by ???%");
    }
}
