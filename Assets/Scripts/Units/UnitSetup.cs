using System;
using Units;
using UnityEngine;

[CreateAssetMenu(fileName = "Unit", menuName = "Unit", order = 53)]
public class UnitSetup : AttackerSetup
{
    [SerializeField] private Faction _faction;
    [SerializeField] private BattleRole _battleRole;
    [SerializeField] private float _approachDistance;
    [SerializeField] private float _movementSpeed;

    public Faction Faction => _faction;
    public BattleRole BattleRole => _battleRole;
    public float ApproachDistance => _approachDistance;
    public float MovementSpeed => _movementSpeed;

    public void IncreaseSpeed(float defaultSpeedBoostPortion)
    {
        if (defaultSpeedBoostPortion < 0 || defaultSpeedBoostPortion > 1)
            throw new ArgumentOutOfRangeException("Speed boost portion is a number between 0 and 1.");

        _movementSpeed += _movementSpeed * defaultSpeedBoostPortion;
    }
}