using UnityEngine;

namespace EnemyBehaviorSystem
{
    public class EnemyUpgradeService : MonoBehaviour
    {
        public void ImroveResourceExtraction()
        {
            Debug.Log("Я улучшил добычу ресурсов!");
        }

        public void ImroveRandomStats()
        {
            Debug.Log("Я улучшил какую-то характиристику!");
        }

        public void ImproveUnitAttack()
        {
            Debug.Log("Я улучшил характиристику атаки!");
        }

        public void ImproveUnitHealth()
        {
            Debug.Log("Я улучшил характиристику здоровья!");
        }
    }
}