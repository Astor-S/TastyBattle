using System;
using Units;
using UnityEngine;

[CreateAssetMenu(fileName="Unit", menuName="Unit", order=51)]
public class UnitSetup : ScriptableObject
{
    [SerializeField] private Faction _faction;
    [SerializeField] private BattleRole _battleRole;
    [SerializeField] private float _attackDamage;
    [SerializeField] private float _attackSpeed;
    [SerializeField] private float _maxHealthPoints;
    [SerializeField] private float _speed;

    private Faction _originalFaction;
    private BattleRole _originalBattleRole;
    private float _originalAttackDamage;
    private float _originalAttackSpeed;
    private float _originalMaxHealthPoints;
    private float _originalSpeed;

    public event Action MaxHealthIncreased;

    public Faction Faction => _faction;
    public BattleRole BattleRole => _battleRole;
    public float AttackSpeed => _attackSpeed;
    public float AttackDamage => _attackDamage;
    public float MaxHealthPoints => _maxHealthPoints;
    public float Speed => _speed;

    private void OnValidate()
    {
        _originalFaction = _faction;
        _originalBattleRole = _battleRole;
        _originalAttackDamage = _attackDamage;
        _originalAttackSpeed = _attackSpeed;
        _originalMaxHealthPoints = _maxHealthPoints;
        _originalSpeed = _speed;
    }

    private void OnEnable()
    {
        Application.quitting += Reset;
    }

    private void OnDisable()
    {
        Application.quitting -= Reset;
    }

    private void Reset()
    {
        _faction = _originalFaction;
        _battleRole = _originalBattleRole;
        _attackDamage = _originalAttackDamage;
        _attackSpeed = _originalAttackSpeed;
        _maxHealthPoints = _originalMaxHealthPoints;
        _speed = _originalSpeed;
    }

    public void IncreaseDamage(float damageBoostPortion)
    {
        if (damageBoostPortion < 0 || damageBoostPortion > 1)
            throw new ArgumentOutOfRangeException("Damage boost portion is a number between 0 and 1.");

        _attackDamage += _attackDamage * damageBoostPortion;
    }

    public void IncreaseHealth(float healthBoostPortion)
    {
        if (healthBoostPortion < 0 || healthBoostPortion > 1)
            throw new ArgumentOutOfRangeException("Damage boost portion is a number between 0 and 1.");

        _maxHealthPoints += _maxHealthPoints * healthBoostPortion;

        MaxHealthIncreased?.Invoke();
    }
}
