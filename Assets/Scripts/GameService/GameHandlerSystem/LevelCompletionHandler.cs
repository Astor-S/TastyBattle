using UnityEngine;
using UI.Screens;

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
            _levelRewarder.AwardCoins();
            _levelUnlocker.RequestToOpenLevel();
            _completeScreen.Open();
            StartCoroutine(_pauseHandler.PauseGameDelayed());
        }
    }
}