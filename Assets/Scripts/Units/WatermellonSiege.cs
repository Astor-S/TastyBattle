using AttackSystem;

namespace Units
{
    public class WatermellonSiege : Unit
    {
        public WatermellonSiege(UnitSetup setup, DamagableTarget enemyBase)
            : base(setup, enemyBase)
        {
        }

        public new WatermellonSiegeSetup Stats => base.Stats as WatermellonSiegeSetup;
    }
}