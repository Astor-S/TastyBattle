using System;
using System.Collections.Generic;
using UnityEngine;

public class DetectionSystem : MonoBehaviour
{
    private const string Enemy = nameof(Enemy);
    private const string Player = nameof(Player);

    [SerializeField] private DamagableTarget _currentUnit;

    private Queue<DamagableTarget> _detectedUnits = new();
    private string _enemyLayer;
    private DamagableTarget _enemyBase;

    public event Action<DamagableTarget> TargetChanged;

    private void Start()
    {
        TargetChanged?.Invoke(_enemyBase);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out DamagableTarget unit) && _detectedUnits.Contains(unit) == false)
        {
            if (LayerMask.LayerToName(unit.gameObject.layer) == _enemyLayer)
            {
                unit.Dying += OnDetectedUnitDied;

                _detectedUnits.Enqueue(unit);

                if (_detectedUnits.Count == 1)
                    TargetChanged?.Invoke(unit);
            }
        }
    }

    private void OnDetectedUnitDied(DamagableTarget unit)
    {
        unit.Dying -= OnDetectedUnitDied;

        while (_detectedUnits.Count > 0 && (_detectedUnits.Peek() == null || _detectedUnits.Peek().IsAlive == false))
            _detectedUnits.Dequeue();

        if (_detectedUnits.Count == 0)
            TargetChanged?.Invoke(_enemyBase);
        else
            TargetChanged?.Invoke(_detectedUnits.Peek());
    }

    public void Init(int layer, DamagableTarget enemyBase)
    {
        if (LayerMask.LayerToName(layer) == Enemy)
            _enemyLayer = Player;
        else
            _enemyLayer = Enemy;

        _enemyBase = enemyBase;

        gameObject.SetActive(true);
    }
}
