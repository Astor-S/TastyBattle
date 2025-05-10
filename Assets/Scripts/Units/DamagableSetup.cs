using System;
using Units;
using UnityEngine;

[CreateAssetMenu(fileName = "DamagableTarget", menuName = "Scriptable Objects/DamagableTarget", order = 51)]
public class DamagableSetup : ScriptableObject
{
    public const int MinValue = 1;
    public const int MaxHPValue = 1000;

    [SerializeField] private BattleRole _battleRole;
    [SerializeField, Range(MinValue, MaxHPValue)] private float _maxHealthPoints;
    [SerializeField] private int _reward;

    public BattleRole BattleRole => _battleRole;
    public float MaxHealthPoints { get; private set; }
    public int Reward => _reward;

    private void OnValidate() =>
        Initialize();

    private void Awake() =>
        Initialize();

    protected virtual void Initialize() => 
        MaxHealthPoints = _maxHealthPoints;
}
