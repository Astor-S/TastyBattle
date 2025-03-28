using System;
using UnityEngine;
using AttackSystem;
using AttackSystem.AttackHandlers;

public abstract class GameEntityBehaviour : MonoBehaviour
{
    [SerializeField] private DamagableTarget _damagableTarget;
    [SerializeField] private AttackHandler _attackHandler;
    [SerializeField] private DetectionSystem _detectionSystem;

    private Action<DamagableTarget> _dyingDelegate => (_) => Disable();
    
    private void OnEnable() =>
        _damagableTarget.Dying += _dyingDelegate;

    private void OnDisable() =>
        _damagableTarget.Dying -= _dyingDelegate;

    protected virtual void Disable() 
    {
        if (_attackHandler != null)
            _attackHandler.enabled = false;

        if (_detectionSystem != null)
            _detectionSystem.enabled = false;
    }
}