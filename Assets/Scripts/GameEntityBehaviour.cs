using UnityEngine;

public abstract class GameEntityBehaviour : MonoBehaviour
{
    [SerializeField] private DamagableTarget _damagableTarget;
    [SerializeField] private DetectionSystem _detectionSystem;
    
    private void OnEnable() =>
        _damagableTarget.Died += Disable;

    private void OnDisable() =>
        _damagableTarget.Died -= Disable;

    protected virtual void Disable() 
    {
        if (_detectionSystem != null)
            _detectionSystem.enabled = false;
    }
}