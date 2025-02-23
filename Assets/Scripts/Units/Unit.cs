using System;
using UnityEngine;

public class Unit : MonoBehaviour, IDamagable
{
    [SerializeField] private Health _health;

    public Health Health => _health;

    public event Action<Unit> Died;

    private void OnEnable() => 
        _health.Died += OnDied;

    private void OnDisable() => 
        _health.Died -= OnDied;

    public void TakeDamage(float damage) =>
        _health.Reduce(damage);

    private void OnDied() =>
        Died?.Invoke(this);
}