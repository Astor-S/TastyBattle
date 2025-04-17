using UnityEngine;
using UI.Screens.ScreenButtons;
using YG;

namespace GameService.GameHandlerSystem
{
    public class LevelRewarder : MonoBehaviour
    {
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
            AddNewLeaderboardScores();
        }

        private void AddNewLeaderboardScores()
        {
            //YG2.SetLeaderboard(string "техническое название таблицы", int новый рекорд);
        }
    }
}