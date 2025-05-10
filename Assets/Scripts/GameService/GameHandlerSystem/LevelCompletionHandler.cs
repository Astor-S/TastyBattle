using UnityEngine;
using GameService.GameHandlerSystem.Handlers;
using UI.Screens;
using YG;
using UnityEngine.SceneManagement;

namespace GameService.GameHandlerSystem
{
    public class LevelCompletionHandler : MonoBehaviour
    {
        [SerializeField] private LevelRewarder _levelRewarder;
        [SerializeField] private LevelUnlocker _levelUnlocker;
        [SerializeField] private CompleteScreen _completeScreen;
        [SerializeField] private PauseHandler _pauseHandler;

        public void HandleLevelCompletion()
        {
            YG2.MetricaSend($"level{SceneManager.GetActiveScene().buildIndex}_complete");
            _levelRewarder.AwardCoins();
            _levelUnlocker.RequestToOpenLevel();
            _completeScreen.Open();
            StartCoroutine(_pauseHandler.PauseGameDelayed());
        }
    }
}