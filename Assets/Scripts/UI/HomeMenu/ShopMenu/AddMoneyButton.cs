using UnityEngine;
using YG;
using GameService;

namespace UI.HomeMenu.ShopMenu
{
    public class AddMoneyButton : MenuButton
    {
        private readonly int _coinsForWathAD = 200;

        [SerializeField] private BalanceDisplay _balanceDisplayShop;
        [SerializeField] private RewardAdService _rewardAdService;

        private void OnEnable()
        {
            _rewardAdService.RewardReceived += AddMoney;
        }

        private void OnDisable()
        {
            _rewardAdService.RewardReceived -= AddMoney;
        }

        //public override void OnButtonClick() =>
        //    _rewardAdService.ShowRewardAd(0);

        private void AddMoney()
        {
            YG2.saves.balanceMoney += _coinsForWathAD;
            YG2.SaveProgress();
            _balanceDisplayShop.RefreshBalance();
        }
    }
}