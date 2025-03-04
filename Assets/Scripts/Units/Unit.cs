using StructureElements;
using Units;

public class Unit : Transformable
{
    public Faction Faction { get; }
    public BattleRole BattleRole { get; }

    public Unit(UnitSetup setup)
    {
        Faction = setup.Faction;
        BattleRole = setup.BattleRole;
    }
}
