using StructureElements;
using Units;
using UnityEngine;

namespace Buildings
{
    public class Building : Transformable
    {
        public Building(
            DamagableSetup setup,
            Vector3 position = default,
            Quaternion rotation = default,
            Vector3 scale = default)
            : base(position, rotation, scale)
        {
            Stats = setup;
        }

        public DamagableSetup Stats { get; }
    }
}
