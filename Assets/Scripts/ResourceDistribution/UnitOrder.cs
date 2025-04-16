public class UnitOrder : Order
{
    public UnitSetup Setup { get; }

    public UnitOrder(UnitSetup setup)
    {
        Setup = setup;
    }
}