using UnityEngine;

public class UnitOrderHandler : OrderHandler
{
    [SerializeField] private UnitSetup _unitSetup;

    public UnitSetup Setup => _unitSetup;

    protected override Order InitializeOrder()
    {
        return new UnitOrder(_unitSetup);
    }
}
