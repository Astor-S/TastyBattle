using UnityEngine;
using UnityEngine.UI;
using YG;

namespace SDKProperties
{
    public class LeaderboardHandler : MonoBehaviour
    {
        public const string LeaderboardName = "Leaderboard";

        [SerializeField] private Transform _leaderboard;
        [SerializeField] private Button _authButton;

        private void OnEnable()
        {
            TryShowLeaderboard();

            YG2.onGetSDKData += TryShowLeaderboard;
        }

        private void OnDisable() =>
            YG2.onGetSDKData -= TryShowLeaderboard;

        public void SetScore(int score)
        {
            if (score >= 0)
            {
                YG2.saves.Score += score;
                YG2.SetLeaderboard(LeaderboardName, YG2.saves.Score);

                YG2.SaveProgress();
            }
        }

        public void Authorizate() =>
            YG2.OpenAuthDialog();

        private void TryShowLeaderboard()
        {
            _leaderboard.gameObject.SetActive(YG2.player.auth);
            _authButton.gameObject.SetActive(YG2.player.auth == false);
        }
    }
}