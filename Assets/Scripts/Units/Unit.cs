using AttackSystem;
using StructureElements;
using UnityEngine;

namespace Units
{
    public class Unit : Transformable
    {
        private const string Enemy = nameof(Enemy);
        private const string Player = nameof(Player);

        public Faction Faction { get; }
        public BattleRole BattleRole { get; }
        public UnitSetup Stats { get; }
        public DamagableTarget EnemyBase { get; }
        public LayerMask OwnerMask { get; }

        public Unit(UnitSetup setup, DamagableTarget enemyBase)
        {
            Stats = setup;
            Faction = setup.Faction;
            BattleRole = setup.BattleRole;
            EnemyBase = enemyBase;

            if (LayerMask.LayerToName(EnemyBase.gameObject.layer) == Player)
                OwnerMask = LayerMask.NameToLayer(Enemy);
            else
                OwnerMask = LayerMask.NameToLayer(Player);
        }
    }
}