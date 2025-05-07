using System;
using System.Collections;
using UnityEngine;

public class Mine : MonoBehaviour, IIncomeSource, IUpgradable
{
    [SerializeField, Min(0.5f)] private float _incomeCooldown;
    [SerializeField] private int _incomeValue;

    private bool _isMining = true;

    public event Action<int, IIncomeSource> ResourceRecieved;

    public UpgradeHandler UpgradeHandler { get; set; }
    public int IncomeValue => _incomeValue;

    private void Start() => 
        StartCoroutine(GetIncome());

    private IEnumerator GetIncome()
    {
        WaitForSeconds cooldownWaitng = new(_incomeCooldown);

        while (_isMining)
        {
            yield return cooldownWaitng;

            ResourceRecieved?.Invoke(UpgradeHandler.GetIncreasedIncome(this), this);
        }
    }
}
