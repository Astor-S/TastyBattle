using System;
using System.Collections;
using UnityEngine;

public class Mine : MonoBehaviour, IIncomeSource
{
    [SerializeField, Min(0.5f)] private float _incomeCooldown;
    [SerializeField] private int _incomeValue;

    private bool _isMining = true;

    public event Action<int, IIncomeSource> ResourceRecieved;

    private void Start()
    {
        StartCoroutine(GetIncome());
    }

    public void IncreaseIncome(float portion)
    {
        _incomeValue += (int)(_incomeValue * portion);
    }

    private IEnumerator GetIncome()
    {
        WaitForSeconds cooldownWaitng = new(_incomeCooldown);

        while (_isMining)
        {
            yield return cooldownWaitng;

            ResourceRecieved?.Invoke(_incomeValue, this);
        }
    }
}
