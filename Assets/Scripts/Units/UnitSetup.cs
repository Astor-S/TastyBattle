using Units;
using UnityEngine;

[CreateAssetMenu(fileName = "Unit", menuName = "Unit", order = 53)]
public class UnitSetup : AttackerUnitSetup
{
    [SerializeField] private Faction _faction;
    [SerializeField] private BattleRole _battleRole;
    [SerializeField] private float _approachDistance;
    [SerializeField] private float _movementSpeed;

    public Faction Faction => _faction;
    public BattleRole BattleRole => _battleRole;
    public float ApproachDistance => _approachDistance;
    public float MovementSpeed => _movementSpeed;
}
