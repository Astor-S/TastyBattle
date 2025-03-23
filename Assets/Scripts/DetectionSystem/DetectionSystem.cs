using System;
using System.Collections.Generic;
using UnityEngine;

public class DetectionSystem : MonoBehaviour
{
    private const string Enemy = nameof(Enemy);
    private const string Player = nameof(Player);

    [SerializeField] private DamagableTarget _currentUnit;
    [SerializeField] private Transform _baseTransform;

    private Queue<DamagableTarget> _detectedUnits = new();
    private string _enemyLayer;
    private DamagableTarget _enemyBase;

    public DamagableTarget CurrentTarget { get; private set; } = null;

    public event Action<DamagableTarget> TargetChanged;

    private void Awake()
    {
        CurrentTarget = _enemyBase;
    }

    private void Start()
    {
        TargetChanged?.Invoke(_enemyBase);
    }

    private void FixedUpdate()
    {
        if (CurrentTarget != null)
            _baseTransform.LookAt(CurrentTarget.transform.position);
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
                {
                    CurrentTarget = unit;
                    TargetChanged?.Invoke(CurrentTarget);
                }
            }
        }
    }

    private void OnDetectedUnitDied(DamagableTarget unit)
    {
        unit.Dying -= OnDetectedUnitDied;

        while (_detectedUnits.Count > 0 && (_detectedUnits.Peek() == null || _detectedUnits.Peek().IsAlive == false))
            _detectedUnits.Dequeue();

        if (_detectedUnits.Count == 0)
            CurrentTarget = _enemyBase;
        else
            CurrentTarget = _detectedUnits.Peek();

        TargetChanged?.Invoke(CurrentTarget);
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
