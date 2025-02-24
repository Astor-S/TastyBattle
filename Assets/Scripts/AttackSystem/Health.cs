using System;
using System.Collections;
using UnityEngine;

public class Health : MonoBehaviour
{
    private const float MinValue = 0;

    [SerializeField] private float _maxValue;

    private float _deathTime = 1.5f;
    private WaitForSeconds _sleepTime;
    private Coroutine _coroutine;

    public event Action<float, float> ValueChanged;
    public event Action Died;

    public float Value { get; private set; }
    public float MaxValue => _maxValue;
    public bool IsAlive => Value > 0;

    private void Start()
    {
        _sleepTime = new WaitForSeconds(_deathTime);

        Value = MaxValue;
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
        ValueChanged?.Invoke(value, _maxValue);
    }

    private IEnumerator ApplyDeath()
    {
        Died?.Invoke();

        yield return _sleepTime;

        Destroy(gameObject);
    }
}