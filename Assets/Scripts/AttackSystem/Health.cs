using System;
using System.Collections;
using UnityEngine;

public class Health : MonoBehaviour
{
    private const float MinValue = 0;
    private const float Quater = 4;
    private const float Half = 2;

    private UnitSetup _stats;
    private float _deathTime = 1.5f;
    private Coroutine _coroutine;
    private bool _isHalfHP = false;
    private bool _isQuaterHP = false;

    public event Action<float, float> ValueChanged;
    public event Action Died;
    public event Action HalfHP;
    public event Action QuaterHP;

    public float Value { get; private set; }
    public float MaxValue => _maxValue;
    public bool IsAlive => Value > MinValue;

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
        ValueChanged?.Invoke(value, _maxValue);

        if (MaxValue / Quater >= Value && !_isQuaterHP)
        {
            _isQuaterHP = true;
            QuaterHP?.Invoke();
        }
        else if (MaxValue / Half >= Value && !_isHalfHP)
        {
            _isHalfHP = true;
            HalfHP?.Invoke();
        }
        
        ValueChanged?.Invoke(value, MaxValue);
    }

    private IEnumerator ApplyDeath()
    {
        Died?.Invoke();

        yield return new WaitForSeconds(_deathTime);

        Destroy(gameObject);
    }
}