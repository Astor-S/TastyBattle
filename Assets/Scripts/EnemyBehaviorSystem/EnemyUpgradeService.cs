using UnityEngine;
using ResourceDistribution;

namespace EnemyBehaviorSystem
{
    public class EnemyUpgradeService : MonoBehaviour
    {
        [SerializeField] private UpgradeOrderHandler _unitHealthStat;
        [SerializeField] private UpgradeOrderHandler _unitDamagStat;
        [SerializeField] private UpgradeOrderHandler _resourceExtraction;

        public void ImproveResourceExtraction() =>
            _resourceExtraction.MakeOrder();

        public void ImproveRandomUnitStats()
        {
            float improveUnitAttackChance = 0.5f;

            if (Random.value < improveUnitAttackChance)
                ImproveUnitAttack();
            else
                ImproveUnitHealth();
        }

        private void ImproveUnitAttack() =>
            _unitDamagStat.MakeOrder();

        private void ImproveUnitHealth() =>
            _unitHealthStat.MakeOrder();
    }
}