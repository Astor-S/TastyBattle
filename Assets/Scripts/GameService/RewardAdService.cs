using System;
using UnityEngine;
using YG;

namespace GameService
{
    public class RewardAdService : MonoBehaviour
    {
        public event Action RewardReceived;

        private void OnEnable() => 
            YG2.onRewardAdv += Reward;

        private void OnDisable() => 
            YG2.onRewardAdv -= Reward;

        public void ShowRewardAd(string id) => 
            YG2.RewardedAdvShow(id);

        private void Reward(string id) =>
            RewardReceived?.Invoke();
    }
}