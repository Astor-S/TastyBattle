using UnityEngine;

namespace EnemyBehaviorSystem
{
    public class EnemyUpgradeService : MonoBehaviour
    {
        [SerializeField] private UpgradeOrderHandler _unitHealthStat;
        [SerializeField] private UpgradeOrderHandler _unitDamagStat;

        public void ImproveResourceExtraction()
        {
            Debug.Log("Я улучшил добычу ресурсов!");
        }

        public void ImproveRandomUnitStats()
        {
            float improveUnitAttackChance = 0.5f;

            if (Random.value < improveUnitAttackChance)
                ImproveUnitAttack();
            else
                ImproveUnitHealth();
        }

        private void ImproveUnitAttack()
        {
            _unitDamagStat.OrderUnit();
            Debug.Log("Я улучшил характиристику атаки!");
        }

        private void ImproveUnitHealth()
        {
            _unitHealthStat.OrderUnit();
            Debug.Log("Я улучшил характиристику здоровья!");
        }
    }
}