using UnityEngine;
using AttackSystem;

public abstract class GameEntityBehaviour : MonoBehaviour
{
    [SerializeField] private DamagableTarget _damagableTarget;
    [SerializeField] private AttackHandler _attackHandler;
    [SerializeField] private DetectionSystem _detectionSystem;
    
    private void OnEnable() =>
        _damagableTarget.Died += Disable;

    private void OnDisable() =>
        _damagableTarget.Died -= Disable;

    protected virtual void Disable() 
    {
        if (_attackHandler != null)
            _attackHandler.enabled = false;

        if (_detectionSystem != null)
            _detectionSystem.enabled = false;
    }
}