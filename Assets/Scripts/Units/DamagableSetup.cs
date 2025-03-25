using System;
using UnityEngine;

[CreateAssetMenu(fileName = "DamagableTarget", menuName = "Scriptable Objects/DamagableTarget", order = 51)]
public class DamagableSetup : ScriptableObject
{
    [SerializeField] private LayerMask _ownerMask;
    [SerializeField] private float _maxHealthPoints;

    public event Action MaxHealthIncreased;

    public LayerMask OwnerMask { get; private set; }
    public float MaxHealthPoints { get; private set; }

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
