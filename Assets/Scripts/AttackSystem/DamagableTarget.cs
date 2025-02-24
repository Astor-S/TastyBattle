using System;
using UnityEngine;

public class DamagableTarget : MonoBehaviour, IDamagable
{
    [SerializeField] private Health _health;
    [SerializeField] private AttackSystem _attackSystem;
    [SerializeField] private UnitMovementInput _movementInput;

    public Health Health => _health;

    public event Action Died;

    private void OnEnable() => 
        _health.Died += OnDied;

    private void OnDisable() => 
        _health.Died -= OnDied;

    public void TakeDamage(float damage) =>
        _health.Reduce(damage);

    private void OnDied()
    {
        Died?.Invoke();

        GetComponent<Collider>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;

        _attackSystem.enabled = false;
        _movementInput.enabled = false;
        enabled = false;
    }
}