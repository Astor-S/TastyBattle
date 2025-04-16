using System;
using UnityEngine;

namespace GameService
{
    public class RewardAdService : MonoBehaviour
    {
        public event Action RewardReceived;

        //private void OnEnable()
        //{
        //    YandexGame.RewardVideoEvent += Rewarded;
        //}

        //private void OnDisable()
        //{
        //    YandexGame.RewardVideoEvent -= Rewarded;
        //}

        public void ShowRewardAd(int id)
        {
            //YandexGame.RewVideoShow(id);
        }

        private void Rewarded(int _) =>
            RewardReceived?.Invoke();
    }
}