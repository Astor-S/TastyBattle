using UnityEngine;

public class UnitBehaviour : MonoBehaviour
{
    [SerializeField] private DamagableTarget _damagableTarget;
    [SerializeField] private AttackSystem _attackSystem;
    [SerializeField] private UnitMovementInput _movementInput;
    [SerializeField] private DetectionSystem _detectionSystem;

    private void OnEnable() => 
        _damagableTarget.Died += Disable;

    private void OnDisable() => 
        _damagableTarget.Died -= Disable;

    private void Disable()
    {
        if (_attackSystem != null)
            _attackSystem.enabled = false;
        if (_movementInput != null)
            _movementInput.enabled = false;
        if (_detectionSystem != null)
            _detectionSystem.enabled = false;
    }
}
