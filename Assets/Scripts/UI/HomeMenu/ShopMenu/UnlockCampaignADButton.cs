using GameService;
using UnityEngine;
using YG;

namespace UI.HomeMenu.ShopMenu
{
    public class UnlockCampaignADButton : MenuButton
    {
        [SerializeField] private RewardAdService _rewardAdService;
        [SerializeField] private Levels _unlockLevels = Levels.Level21;

        private void OnEnable()
        {
            _rewardAdService.RewardReceived += UnlockCampaign;
        }

        private void OnDisable()
        {
            _rewardAdService.RewardReceived -= UnlockCampaign;
        }

        public override void OnButtonClick() =>
            _rewardAdService.ShowRewardAd("campaign");

        private void UnlockCampaign()
        {
            YG2.saves.openedLevels.Add(_unlockLevels);
            YG2.SaveProgress();
        }
    }
}