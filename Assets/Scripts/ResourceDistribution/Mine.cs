using System;
using System.Collections;
using UnityEngine;

public class Mine : MonoBehaviour, IIncomeSource
{
    [SerializeField, Min(0.5f)] private float _incomeCooldown;
    [SerializeField] private int _incomeValue;
    [SerializeField] private UpgradeHandler _upgradeHandler;

    //private UpgradeHandler _upgradeHandler;
    private bool _isMining = true;

    public event Action<int, IIncomeSource> ResourceRecieved;

    public int IncomeValue => _incomeValue;

    private void Start() => 
        StartCoroutine(GetIncome());

    private IEnumerator GetIncome()
    {
        WaitForSeconds cooldownWaitng = new(_incomeCooldown);

        while (_isMining)
        {
            yield return cooldownWaitng;

            ResourceRecieved?.Invoke(_incomeValue + (int)_upgradeHandler.GetIncreasedIncome(this), this);
        }
    }

    //public void SetUpgrades(UpgradeHandler upgradeHandler) => 
    //    _upgradeHandler = upgradeHandler;
}
