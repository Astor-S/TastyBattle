using UnityEngine;

public abstract class GameEntityBehaviour : MonoBehaviour
{
    [SerializeField] private DamagableTarget _damagableTarget;
    [SerializeField] private AttackSystem _attackSystem;
    [SerializeField] private DetectionSystem _detectionSystem;
    
    private void OnEnable() =>
        _damagableTarget.Dying += Disable;

    private void OnDisable() =>
        _damagableTarget.Dying -= Disable;

    protected virtual void Disable() 
    {
        if (_attackSystem != null)
            _attackSystem.enabled = false;
        if (_detectionSystem != null)
            _detectionSystem.enabled = false;
    }
}