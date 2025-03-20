using StructureElements;
using Units;

public class Unit : Transformable
{
    public Faction Faction { get; }
    public BattleRole BattleRole { get; }
    public UnitSetup Stats { get; }
    public DamagableTarget EnemyBase { get; }

    public Unit(UnitSetup setup, DamagableTarget enemyBase)
    {
        Stats = setup;
        Faction = setup.Faction;
        BattleRole = setup.BattleRole;
        EnemyBase = enemyBase;
    }
}
