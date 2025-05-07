public class UnitOrder : Order
{
    public UnitSetup Setup { get; }

    public UnitOrder(int cost, UnitSetup setup) : base(cost, 1f)
    {
        Setup = setup;
    }
}