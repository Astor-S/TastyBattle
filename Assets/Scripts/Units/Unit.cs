using StructureElements;
using Units;

public class Unit : Transformable
{
    private AttackHandler _attackHandler;

    public Unit(UnitSetup setup, DetectionSystem detectionSystem, Health health)
    {
        Stats = setup;
        Faction = setup.Faction;
        BattleRole = setup.BattleRole;
        _attackHandler = new AttackHandler(detectionSystem, health);
    }

    public Faction Faction { get; }
    public BattleRole BattleRole { get; }
    public UnitSetup Stats { get; }

    public AttackHandler AttackHandler => _attackHandler;
}
