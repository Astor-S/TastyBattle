using AttackSystem;
using StructureElements;

namespace Units
{
    public class Unit : Transformable
    {
        private float _currentMovementSpeed;
        private float _currentAttackSpeed;

        public Faction Faction { get; }
        public BattleRole BattleRole { get; }
        public UnitSetup Stats { get; }
        public DamagableTarget EnemyBase { get; }

        public float CurrentMovementSpeed => _currentMovementSpeed;
        public float CurrentAttackSpeed => _currentAttackSpeed;

        public Unit(UnitSetup setup, DamagableTarget enemyBase)
        {
            Stats = setup;
            Faction = setup.Faction;
            BattleRole = setup.BattleRole;
            EnemyBase = enemyBase;

            _currentMovementSpeed = Stats.MovementSpeed;
            _currentAttackSpeed = Stats.AttackSpeed;
        }

        public void SetMovementSpeed(float newSpeed) =>
            _currentMovementSpeed = newSpeed;

        public void SetAttackSpeed(float newSpeed) =>
            _currentAttackSpeed = newSpeed;
    }
}