using AttackSystem;
using StructureElements;
using UnityEngine;

namespace Units
{
    public class Unit : Transformable
    {
        public Unit(UnitSetup setup, DamagableTarget enemyBase)
        {
            Stats = setup;
            Faction = setup.Faction;
            BattleRole = setup.BattleRole;
            EnemyBase = enemyBase;

            if (EnemyBase.gameObject.layer == LayersData.PlayerLayerNumber)
                OwnerMask = LayersData.EnemyLayerNumber;
            else
                OwnerMask = LayersData.PlayerLayerNumber;
        }

        public Faction Faction { get; }
        public BattleRole BattleRole { get; }
        public UnitSetup Stats { get; }
        public DamagableTarget EnemyBase { get; }
        public LayerMask OwnerMask { get; }
    }
}