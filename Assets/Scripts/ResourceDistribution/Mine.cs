using System;
using System.Collections;
using UnityEngine;

public class Mine : MonoBehaviour, IIncomeSource
{
    private const string Player = nameof(Player);

    [SerializeField, Min(0.5f)] private float _incomeCooldown;
    [SerializeField] private int _incomeValue;

    private bool _isMining = true;
    private UpgradesData _upgradesData;

    public event Action<int, IIncomeSource> ResourceRecieved;

    public int IncomeValue => _incomeValue;

    private void Start()
    {
        StartCoroutine(GetIncome());

        _upgradesData = gameObject.layer == LayerMask.NameToLayer(Player) ? Upgrades.Player : Upgrades.Enemy;
    }

    private IEnumerator GetIncome()
    {
        WaitForSeconds cooldownWaitng = new(_incomeCooldown);

        while (_isMining)
        {
            yield return cooldownWaitng;

            ResourceRecieved?.Invoke(_upgradesData.GetIncreasedIncome(this), this);
        }
    }
}
