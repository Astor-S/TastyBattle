using System;
using UnityEngine;
using GameService;

namespace UI.Screens.ScreenButtons
{
    public class CoinDoublingButton : MonoBehaviour
    {
        [SerializeField] private RewardAdService _rewardAdService;

        public event Action DoubledAwards;

        private void OnEnable() => 
            _rewardAdService.CoinsReceived += AddDoubleAwards;

        private void OnDisable() => 
            _rewardAdService.CoinsReceived -= AddDoubleAwards;

        public void OnButtonClick() =>
            _rewardAdService.ShowRewardAd(default);

        private void AddDoubleAwards()
        {
            DoubledAwards?.Invoke();
            gameObject.SetActive(false);
        }
    }
}