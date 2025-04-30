using System;
using Units;
using UnityEngine;

[CreateAssetMenu(fileName = "Unit", menuName = "Scriptable Objects/Unit", order = 53)]
public class UnitSetup : AttackerSetup
{
    [SerializeField] private Faction _faction;
    [SerializeField] private float _movementSpeed;

    public Faction Faction => _faction;
    public float MovementSpeed { get; private set; }

    protected override void Initialize()
    {
        base.Initialize();

        MovementSpeed = _movementSpeed;
    }
}
