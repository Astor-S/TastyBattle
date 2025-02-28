using UnityEngine;
using Units;

namespace EnemyBehaviorSystem
{
    public class EnemySummonerService : MonoBehaviour
    {
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
            Debug.Log("Я призвал дальника");
        }

        private void SummonMeleeUnit()
        {
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