using System;
using System.Collections;
using UnityEngine;

public class Health : MonoBehaviour
{
    private const float MinValue = 0;

    private UnitSetup _stats;
    private float _deathTime = 1.5f;
    private Coroutine _coroutine;

    public event Action<float, float> ValueChanged;
    public event Action Died;

    public float Value { get; private set; }
    public float MaxValue => _stats.MaxHealthPoints;
    public bool IsAlive => Value > 0;

    public void Init(UnitSetup unitSetup)
    {
        _stats = unitSetup;
        Value = unitSetup.MaxHealthPoints;
    }

    public void Reduce(float damage)
    {
        if (damage < 0)
            throw new ArgumentOutOfRangeException(nameof(damage));

        float newHealth = Mathf.Max(Value - damage, MinValue);
        UpdateValue(newHealth);

        if (IsAlive == false)
            _coroutine ??= StartCoroutine(nameof(ApplyDeath));
    }

    private void UpdateValue(float value)
    {
        Value = value;
        ValueChanged?.Invoke(value, MaxValue);
    }

    private IEnumerator ApplyDeath()
    {
        Died?.Invoke();

        yield return new WaitForSeconds(_deathTime);

        Destroy(gameObject);
    }
}