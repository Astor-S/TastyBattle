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
            Debug.Log("� ������� ��������");
        }

        private void SummonMeleeUnit()
        {
            _melee.OrderUnit();
            Debug.Log("� ������� ���������!");
        }

        private void SummonTankUnit()
        {
            Debug.Log("� ������� �����!");
        }

        private void SummonSiegeUnit()
        {
            Debug.Log("� ������� ��������!");
        }
    }
}