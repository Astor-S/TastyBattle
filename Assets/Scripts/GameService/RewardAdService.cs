using System;
using UnityEngine;
using YG;

namespace GameService
{
    public class RewardAdService : MonoBehaviour
    {
        public event Action CoinsReceived;
        public event Action SkinReceived;
        public event Action CampaignReceived;

        private string _campaign = "campaign";
        private string _coinsRewardId = "coins";
        private string _skinRewardId = "skin";

        private void OnEnable() =>
            YG2.onRewardAdv += Reward;

        private void OnDisable() =>
            YG2.onRewardAdv -= Reward;

        public void ShowRewardAd(string id) =>
            YG2.RewardedAdvShow(id);

        private void Reward(string id)
        {
            if (id == _coinsRewardId)
                CoinsReceived?.Invoke();
            else if (id == _skinRewardId)
                SkinReceived?.Invoke();
            else if (id == _campaign)
                CampaignReceived?.Invoke();
        }
    }
}