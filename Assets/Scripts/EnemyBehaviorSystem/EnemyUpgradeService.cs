using UnityEngine;

namespace EnemyBehaviorSystem
{
    public class EnemyUpgradeService : MonoBehaviour
    {
        [SerializeField] private UpgradeOrderHandler _unitHealthStat;
        [SerializeField] private UpgradeOrderHandler _unitDamagStat;
        private UpgradeHandler _resourceExtraction;// как инициализировать?

        public void ImproveResourceExtraction() =>
            _resourceExtraction.IncreaseIncome();

        public void ImproveRandomUnitStats()
        {
            float improveUnitAttackChance = 0.5f;

            if (Random.value < improveUnitAttackChance)
                ImproveUnitAttack();
            else
                ImproveUnitHealth();
        }

        private void ImproveUnitAttack() =>
            _unitDamagStat.OrderUnit();

        private void ImproveUnitHealth() =>
            _unitHealthStat.OrderUnit();
    }
}