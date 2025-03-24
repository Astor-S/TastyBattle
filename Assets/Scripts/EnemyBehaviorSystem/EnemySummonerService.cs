using UnityEngine;
using Units;

namespace EnemyBehaviorSystem
{
    public class EnemySummonerService : MonoBehaviour
    {
        [SerializeField] private UnitOrderHandler _melee;
        [SerializeField] private UnitOrderHandler _range;
        [SerializeField] private UnitOrderHandler _tank;
        [SerializeField] private UnitOrderHandler _siege;

        public void ExecuteFirstSummon() =>
            SummonRangeUnit();

        public void SummonRandomUnit()
        {
            int minRange = 0;
            int maxRange = System.Enum.GetValues(typeof(BattleRole)).Length;

            BattleRole randomBattleRole = (BattleRole)Random.Range(minRange,maxRange);

            switch (randomBattleRole)
            {
                case BattleRole.Melee:
                    SummonMeleeUnit();
                    break;

                case BattleRole.Range:
                    SummonRangeUnit();
                    break;

                case BattleRole.Tank:
                    SummonTankUnit();
                    break;

                case BattleRole.Siege:
                    SummonSiegeUnit();
                    break;
            }
        }

        private void SummonRangeUnit() =>
            _range.OrderUnit();

        private void SummonMeleeUnit() =>
            _melee.OrderUnit();

        private void SummonTankUnit() =>
            _tank.OrderUnit();

        private void SummonSiegeUnit() =>
            _siege.OrderUnit();
    }
}