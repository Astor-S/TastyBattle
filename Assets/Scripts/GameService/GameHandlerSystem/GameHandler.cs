using UnityEngine;

namespace GameService.GameHandlerSystem
{
    public class GameHandler : MonoBehaviour
    {
        [SerializeField] private GameEnder _gameEnder;
        [SerializeField] private LevelCompletionHandler _levelCompletionHandler;

        private void OnGameOver() =>
            _gameEnder.HandleGameOver();

        private void OnCompleteLevel() =>
            _levelCompletionHandler.HandleLevelCompletion();

    }
}