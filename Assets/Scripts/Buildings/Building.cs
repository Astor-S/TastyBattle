using StructureElements;
using UnityEngine;

public class Building : Transformable
{
    public DamagableSetup Stats { get; }

    public Building(
        DamagableSetup setup,
        Vector3 position = default,
        Quaternion rotation = default,
        Vector3 scale = default) :
        base(position, rotation, scale)
    {
        Stats = setup; 
    }
}
