using StructureElements;
using UnityEngine;

public class Building : Transformable, IUpgradable
{
    public DamagableSetup Stats { get; }
    public UpgradeHandler UpgradeHandler { get; }

    public Building(
        DamagableSetup setup,
        UpgradeHandler upgradeHandler,
        Vector3 position = default,
        Quaternion rotation = default,
        Vector3 scale = default) :
        base(position, rotation, scale)
    {
        Stats = setup;
        UpgradeHandler = upgradeHandler;
    }
}
