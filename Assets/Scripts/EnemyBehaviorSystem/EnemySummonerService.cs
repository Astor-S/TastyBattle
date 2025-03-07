using UnityEngine;
using Units;

namespace EnemyBehaviorSystem
{
    public class EnemySummonerService : MonoBehaviour
    {
        [SerializeField] private UnitOrderHandler _melee;
        [SerializeField] private UnitOrderHandler _range;

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

        private void SummonRangeUnit()
        {
            _range.OrderUnit();
            Debug.Log("Я призвал дальника");
        }

        private void SummonMeleeUnit()
        {
            _melee.OrderUnit();
            Debug.Log("Я призвал милишника!");
        }

        private void SummonTankUnit()
        {
            Debug.Log("Я призвал танка!");
        }

        private void SummonSiegeUnit()
        {
            Debug.Log("Я призвал осадника!");
        }
    }
}