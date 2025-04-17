using UnityEngine;
using Buildings;
using AttackSystem;

namespace GameService.GameHandlerSystem
{
    public class GameHandler : MonoBehaviour
    {
        [SerializeField] private MainBuildingPresenter _playerBase;
        [SerializeField] private MainBuildingPresenter _enemyBase;
        [SerializeField] private GameEnder _gameEnder;
        [SerializeField] private LevelCompletionHandler _levelCompletionHandler;

        private void OnEnable()
        {
            if (_playerBase != null)
                _playerBase.DamagableTarget.Dying += OnPlayerBaseDied;

            if (_enemyBase != null)
                _enemyBase.DamagableTarget.Dying += OnEnemyBaseDied;
        }

        private void OnDisable()
        {
            if (_playerBase != null)
                _playerBase.DamagableTarget.Dying -= OnPlayerBaseDied;

            if (_enemyBase != null)
                _enemyBase.DamagableTarget.Dying -= OnEnemyBaseDied;
        }

        private void OnGameOver() =>
            _gameEnder.HandleGameOver();

        private void OnCompleteLevel() =>
            _levelCompletionHandler.HandleLevelCompletion();

        private void OnPlayerBaseDied(DamagableTarget target) =>
            OnGameOver();

        private void OnEnemyBaseDied(DamagableTarget target) =>
            OnCompleteLevel();
    }
}