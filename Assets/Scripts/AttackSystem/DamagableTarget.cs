using System;
using UnityEngine;

public class DamagableTarget : MonoBehaviour, IDamagable
{
    [SerializeField] private Health _health;
    [SerializeField] private Collider _collider;
    [SerializeField] private Rigidbody _rigidbody;

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

        _collider.enabled = false;
        _rigidbody.isKinematic = true;

        enabled = false;
    }
}