using UnityEngine;
using YG;

public class UnitOrderHandler : OrderHandler
{
    [SerializeField] private UnitSetup _unitSetup;

    public UnitSetup Setup => _unitSetup;

    protected override Order InitializeOrder(int initialCost)
    {
        return new UnitOrder(initialCost, _unitSetup);
    }

    protected override void OnOrdered()
    {
        YG2.MetricaSend("unit_ordered");
        Order.IncreaseCost();
    }
}
