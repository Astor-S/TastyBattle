using System;
using UnityEngine;

public abstract class GameEntityBehaviour : MonoBehaviour
{
    [SerializeField] private DamagableTarget _damagableTarget;
    [SerializeField] private AttackSystem _attackSystem;
    [SerializeField] private DetectionSystem _detectionSystem;

    private Action<DamagableTarget> _dyingDelegate => (_) => Disable();
    
    private void OnEnable() =>
        _damagableTarget.Dying += _dyingDelegate;

    private void OnDisable() =>
        _damagableTarget.Dying -= _dyingDelegate;

    protected virtual void Disable() 
    {
        if (_attackSystem != null)
            _attackSystem.enabled = false;
        if (_detectionSystem != null)
            _detectionSystem.enabled = false;
    }
}