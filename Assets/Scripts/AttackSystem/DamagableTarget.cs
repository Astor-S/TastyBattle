using System;
using UnityEngine;

public class DamagableTarget : MonoBehaviour, IDamagable
{
    [SerializeField] private Health _health;
    [SerializeField] private Collider _collider;
    [SerializeField] private Rigidbody _rigidbody;

    public Health Health => _health;

    public event Action Died;
    public event Action HalfHP;
    public event Action QuaterHP;

    private void OnEnable()
    {
        _health.Died += OnDied;
        _health.HalfHP += OnHalfHP;
        _health.QuaterHP += OnQuaterHP;
    }

    private void OnDisable()
    {
        _health.Died -= OnDied;
        _health.HalfHP -= OnHalfHP;
        _health.QuaterHP -= OnQuaterHP;
    }

    private void OnQuaterHP() => 
        QuaterHP?.Invoke();

    private void OnHalfHP() =>
        HalfHP?.Invoke();

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