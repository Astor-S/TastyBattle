using UnityEngine;

namespace EnemyBehaviorSystem
{
    public class EnemyUpgradeService : MonoBehaviour
    {
        public void ImproveResourceExtraction()
        {
            Debug.Log("� ������� ������ ��������!");
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
            Debug.Log("� ������� �������������� �����!");
        }

        private void ImproveUnitHealth()
        {
            Debug.Log("� ������� �������������� ��������!");
        }
    }
}