using UnityEngine;

public class UnitOrderHandler : OrderHandler
{
    [SerializeField] private UnitSetup _unitSetup;

    public UnitSetup Setup => _unitSetup;

    protected override Order InitializeOrder(int initialCost)
    {
        return new UnitOrder(initialCost, _unitSetup);
    }
}
