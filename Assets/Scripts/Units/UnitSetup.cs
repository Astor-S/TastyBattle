using System;
using Units;
using UnityEngine;

[CreateAssetMenu(fileName = "Unit", menuName = "Scriptable Objects/Unit", order = 53)]
public class UnitSetup : AttackerSetup
{
    [SerializeField] private Faction _faction;
    [SerializeField] private BattleRole _battleRole;
    [SerializeField] private float _movementSpeed;

    public Faction Faction { get; private set; }
    public BattleRole BattleRole { get; private set; }
    public float MovementSpeed { get; private set; }

    public void IncreaseSpeed(float defaultSpeedBoostPortion)
    {
        if (defaultSpeedBoostPortion < 0 || defaultSpeedBoostPortion > 1)
            throw new ArgumentOutOfRangeException("Speed boost portion is a number between 0 and 1.");

        MovementSpeed += MovementSpeed * defaultSpeedBoostPortion;
    }

    protected override void Initialize()
    {
        base.Initialize();

        Faction = _faction;
        BattleRole = _battleRole;
        MovementSpeed = _movementSpeed;
    }
}