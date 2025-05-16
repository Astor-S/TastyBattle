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
            _rewardAdService.DoubleCoinsReceived += AddDoubleAwards;

        private void OnDisable() => 
            _rewardAdService.DoubleCoinsReceived -= AddDoubleAwards;

        public void OnButtonClick() =>
            _rewardAdService.ShowRewardAd(_rewardAdService.DoubleCoinsId);

        private void AddDoubleAwards()
        {
            DoubledAwards?.Invoke();
            gameObject.SetActive(false);
        }
    }
}