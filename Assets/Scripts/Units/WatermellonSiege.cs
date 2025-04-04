using AttackSystem;
using Units;

public class WatermellonSiege : Unit
{
    public new WatermellonSiegeSetup Stats => base.Stats as WatermellonSiegeSetup;

    public WatermellonSiege(UnitSetup setup, DamagableTarget enemyBase) : base(setup, enemyBase)
    {
    }
}
