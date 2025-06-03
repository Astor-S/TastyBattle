using UnityEngine;
using GameService.GameHandlerSystem.Counters;
using UI.Screens.ScreenButtons;
using YG;

namespace GameService.GameHandlerSystem
{
    public class LevelRewarder : MonoBehaviour
    {
        [SerializeField] private KilledEnemyCounter _killedEnemyCounter;
        [SerializeField] private CoinDoublingButton _coinDoubling;
        [SerializeField] private int _coinsPerLevel;

        private int _totalCoins;
        private int _levelCoins;

        public int TotalCoins => _totalCoins;

        private void OnEnable()
        {
            _coinDoubling.DoubledAwards += HandleDoubleAwardRequest;
        }

        private void OnDisable()
        {
            _coinDoubling.DoubledAwards -= HandleDoubleAwardRequest;
        }

        public void AwardCoins()
        {
            _levelCoins = _coinsPerLevel + _killedEnemyCounter.EnemiesKilled;
            _totalCoins += _levelCoins;
            SaveProgress();
        }

        private void HandleDoubleAwardRequest()
        {
            _totalCoins += _levelCoins;
            SaveProgress();
        }

        private void SaveProgress()
        {
            YG2.saves.BalanceMoney += _levelCoins;
            YG2.saves.Score += _levelCoins;
            YG2.SaveProgress();
            AddNewLeaderboardScores();
        }

        private void AddNewLeaderboardScores() =>
            YG2.SetLeaderboard("Leaderboard", YG2.saves.Score);
    }
}