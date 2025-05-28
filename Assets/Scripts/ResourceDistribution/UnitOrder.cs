using Units;

namespace ResourceDistribution
{
    public class UnitOrder : Order
    {
        public UnitOrder(int cost, UnitSetup setup)
            : base(cost, 1f)
        {
            Setup = setup;
        }

        public UnitSetup Setup { get; }
    }
}