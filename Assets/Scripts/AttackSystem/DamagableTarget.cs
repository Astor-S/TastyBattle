using System;
using System.Collections;
using UnityEngine;

public class DamagableTarget : MonoBehaviour, IDamagable
{
    [SerializeField] private Collider _collider;
    [SerializeField] private Rigidbody _rigidbody;

    private DamagableSetup _setup;
    private Health _health;
    private float _deathTime = 1.5f;

    public Health Health => _health;

    public event Action Dying;
    public event Action HalfHP;
    public event Action QuaterHP;

    private void Awake()
    {
        _health = new Health(_setup);
    }

    private void OnEnable()
    {
        _health.Dying += Die;
        _health.HalfHP += OnHalfHP;
        _health.QuaterHP += OnQuaterHP;
    }

    private void OnDisable()
    {
        _health.Dying -= Die;
        _health.HalfHP -= OnHalfHP;
        _health.QuaterHP -= OnQuaterHP;
    }

    public void Init(DamagableSetup setup)
    {
        _setup = setup;

        enabled = true;
    }

    private void OnQuaterHP() =>
        QuaterHP?.Invoke();

    private void OnHalfHP() =>
        HalfHP?.Invoke();

    public void TakeDamage(float damage) =>
        _health.Reduce(damage);

    private void Die()
    {
        Dying?.Invoke();
        StartCoroutine(StartDying());
    }

    private IEnumerator StartDying()
    {
        yield return new WaitForSeconds(_deathTime);

        _collider.enabled = false;
        _rigidbody.isKinematic = true;

        enabled = false;
    }
}