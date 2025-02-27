using UnityEngine;

namespace EnemyBehaviorSystem
{
    public class EnemyUpgradeService : MonoBehaviour
    {
        public void ImroveResourceExtraction()
        {
            Debug.Log("Я улучшил добычу ресурсов!");
        }

        public void ImroveRandomUnitStats()
        {
            float improveUnitAttackChance = 0.5f;

            if (Random.value < improveUnitAttackChance)
                ImproveUnitAttack();
            else
                ImproveUnitHealth();
        }

        private void ImproveUnitAttack()
        {
            Debug.Log("Я улучшил характиристику атаки!");
        }

        private void ImproveUnitHealth()
        {
            Debug.Log("Я улучшил характиристику здоровья!");
        }
    }
}