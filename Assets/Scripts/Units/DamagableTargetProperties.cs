using System;
using UnityEngine;

[CreateAssetMenu(fileName = "DamagableTarget", menuName = "DamagableTarget", order = 51)]
public class DamagableTargetProperties : ScriptableObject
{
    [SerializeField] private float _maxHealthPoints;

    public event Action MaxHealthIncreased;

    public float MaxHealthPoints => _maxHealthPoints;

    public void IncreaseHealth(float healthBoostPortion)
    {
        if (healthBoostPortion < 0 || healthBoostPortion > 1)
            throw new ArgumentOutOfRangeException("Damage boost portion is a number between 0 and 1.");

        _maxHealthPoints += _maxHealthPoints * healthBoostPortion;

        MaxHealthIncreased?.Invoke();
    }
}
