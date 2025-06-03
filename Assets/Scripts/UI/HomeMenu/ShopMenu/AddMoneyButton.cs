using UnityEngine;
using YG;
using SDKProperties;

namespace UI.HomeMenu.ShopMenu
{
    public class AddMoneyButton : MenuButton
    {
        private readonly int _coinsForWatchAD = 200;

        [SerializeField] private BalanceDisplay _balanceDisplayShop;
        [SerializeField] private RewardAdService _rewardAdService;

        private void OnEnable() => 
            _rewardAdService.CoinsReceived += AddMoney;

        private void OnDisable() => 
            _rewardAdService.CoinsReceived -= AddMoney;

        public override void OnButtonClick() =>
            _rewardAdService.ShowRewardAd(_rewardAdService.CoinsId);

        private void AddMoney()
        {
            YG2.saves.BalanceMoney += _coinsForWatchAD;
            YG2.SaveProgress();

            _balanceDisplayShop.RefreshBalance();
        }
    }
}