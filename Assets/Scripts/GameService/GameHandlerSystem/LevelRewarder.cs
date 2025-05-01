using UnityEngine;
using GameService.GameHandlerSystem.Counters;
using UI.Screens.ScreenButtons;

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
            //_savesYG.balanceMoney += _levelCoins;
            //_savesYG.score += _levelCoins;
            //YandexGame.SaveProgress();
            AddNewLeaderboardScores();
        }

        private void AddNewLeaderboardScores()
        {
           // int score = _savesYG.score;
            //YG2.SetLeaderboard(string "техническое название таблицы", int новый рекорд);
        }
    }
}