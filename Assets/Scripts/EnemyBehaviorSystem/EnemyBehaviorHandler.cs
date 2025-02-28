using UnityEngine;
using System.Collections;

namespace EnemyBehaviorSystem
{
    public class EnemyBehaviorHandler : MonoBehaviour
    {
        [SerializeField] private EnemySummonerService _summonerService;
        [SerializeField] private EnemyUpgradeService _upgradeService;

        [SerializeField] private float _summonRangeUnitDelay = 2f;
        [SerializeField] private float _improveResourceExtractionDelay = 5f;
        [SerializeField] private float _summonRandomUnitDelay = 5f;
        [SerializeField] private float _improveUnitStatsDelay = 5f;
        [SerializeField] private float _mainLoopStartDelay = 5f;
        [SerializeField] private float _mainLoopInterval = 5f;
        [SerializeField] private float _turnDelay = 5f;

        private void Start()
        {
            StartCoroutine(ExecuteInitialSequence());
        }

        private IEnumerator ExecuteInitialSequence()
        {
            yield return new WaitForSeconds(_summonRangeUnitDelay);
            _summonerService.ExecuteFirstSummon();

            yield return new WaitForSeconds(_improveResourceExtractionDelay);
            _upgradeService.ImproveResourceExtraction();

            yield return new WaitForSeconds(_summonRandomUnitDelay);
            _summonerService.SummonRandomUnit();

            yield return new WaitForSeconds(_improveUnitStatsDelay);
            _upgradeService.ImproveRandomUnitStats();

            yield return new WaitForSeconds(_mainLoopStartDelay);
            StartCoroutine(MainBehaviorLoop());
        }

        private IEnumerator MainBehaviorLoop()
        {
            while (enabled) 
            {
                yield return new WaitForSeconds(_mainLoopInterval);
                yield return StartCoroutine(ExecuteEnemyTurn());
            }
        }

        private IEnumerator ExecuteEnemyTurn()
        {
            TrySummonUnit();

            yield return new WaitForSeconds(_turnDelay);
            TryExecuteRandomImprove();
        }

        private void TrySummonUnit()
        {
            Debug.Log("Попытка призвать юнита...");
            _summonerService.SummonRandomUnit();
        }

        private void TryExecuteRandomImprove()
        {
            float resourceExtractionImproveChance = 0.5f;

            if (Random.value < resourceExtractionImproveChance)
                TryImroveResourceExtraction();
            else
                TryImroveRandomUnitStats();
        }

        private void TryImroveResourceExtraction()
        {
            Debug.Log("Попытка улучшить добычу ресурсов...");
            _upgradeService.ImproveResourceExtraction();
        }

        private void TryImroveRandomUnitStats()
        {
            Debug.Log("Попытка улучшить характеристики юнитов...");
            _upgradeService.ImproveRandomUnitStats();
        }
    }
}