using System.Collections;
using UnityEngine;

namespace EnemyBehaviorSystem
{
    public class EnemyBehaviorHandler : MonoBehaviour
    {
        [SerializeField] private EnemySummonerService _summonerService;
        [SerializeField] private EnemyUpgradeService _upgradeService;

        [SerializeField] private float _initialDelay = 2f;
        [SerializeField] private float _summonRangeUnitDelay = 2f;
        [SerializeField] private float _improveResourceExtractionDelay = 5f;
        [SerializeField] private float _summonRandomUnitDelay = 5f;
        [SerializeField] private float _mainLoopStartDelay = 5f;
        [SerializeField] private float _mainLoopInterval = 5f;

        private void Start()
        {
            StartCoroutine(ExecuteSequence());
        }

        private IEnumerator ExecuteSequence()
        {
            yield return new WaitForSeconds(_initialDelay);
                _summonerService.ExecuteFirstSummon();

            yield return new WaitForSeconds(_summonRangeUnitDelay);
                _upgradeService.ImroveResourceExtraction();

            yield return new WaitForSeconds(_improveResourceExtractionDelay);
                _summonerService.SummonRandomUint();

            yield return new WaitForSeconds(_summonRandomUnitDelay);
                _upgradeService.ImroveRandomStats();
           
            yield return new WaitForSeconds(_mainLoopStartDelay);
                StartCoroutine(MainBehaviorLoop());
        }

        private IEnumerator MainBehaviorLoop()
        {
            while (enabled) 
            {
                yield return new WaitForSeconds(_mainLoopInterval);
                    MainMethod();
            }
        }

        private void MainMethod()
        {
            Debug.Log("Работает основной цикл");
        }
    }
}