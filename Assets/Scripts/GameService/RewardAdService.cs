using System;
using UnityEngine;
using YG;

namespace GameService
{
    public class RewardAdService : MonoBehaviour
    {
        public string CoinReward = nameof(CoinReward);

        public event Action RewardReceived;

        private void OnEnable() =>
            YG2.onRewardAdv += ShowRewardAd;

        private void OnDisable() =>
            YG2.onRewardAdv += ShowRewardAd;

        public void ShowRewardAd(string id) => 
            YG2.RewardedAdvShow(id, Reward);

        private void Reward() =>
            RewardReceived?.Invoke();
    }
}