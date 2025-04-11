using System;
using Units;
using UnityEngine;

[CreateAssetMenu(fileName = "DamagableTarget", menuName = "Scriptable Objects/DamagableTarget", order = 51)]
public class DamagableSetup : ScriptableObject
{
    public const int MinValue = 1;
    public const int MaxHPValue = 1000;

    [SerializeField] private LayerMask _ownerMask;
    [SerializeField] private BattleRole _battleRole;
    [SerializeField, Range(MinValue, MaxHPValue)] private float _maxHealthPoints;

    public event Action MaxHealthIncreased;

    public LayerMask OwnerMask { get; private set; }
    public float MaxHealthPoints { get; private set; }
    public BattleRole BattleRole => _battleRole;

    private void OnValidate() =>
        Initialize();

    public void IncreaseHealth(float healthBoostPortion)
    {
        if (healthBoostPortion < 0 || healthBoostPortion > 1)
            throw new ArgumentOutOfRangeException("Damage boost portion is a number between 0 and 1.");

        MaxHealthPoints += MaxHealthPoints * healthBoostPortion;

        MaxHealthIncreased?.Invoke();
    }

    protected virtual void Initialize()
    {
        MaxHealthPoints = _maxHealthPoints;
        OwnerMask = _ownerMask;
    }
}
