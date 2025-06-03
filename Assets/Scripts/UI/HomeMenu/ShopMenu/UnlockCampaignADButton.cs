using UnityEngine;
using GameService;
using SDKProperties;
using UI.HomeMenu.CampaignMenu;
using YG;

namespace UI.HomeMenu.ShopMenu
{
    public class UnlockCampaignADButton : MenuButton
    {
        [SerializeField] private RewardAdService _rewardAdService;
        [SerializeField] private MapService _mapService;
        [SerializeField] private Levels _unlockLevels = Levels.Level21;

        private void OnEnable() => 
            _rewardAdService.CampaignReceived += UnlockCampaign;

        private void OnDisable() => 
            _rewardAdService.CampaignReceived -= UnlockCampaign;

        public override void OnButtonClick() =>
            _rewardAdService.ShowRewardAd(_rewardAdService.CampaignId);

        private void UnlockCampaign()
        {
            YG2.saves.OpenedLevels.Add(_unlockLevels);
            YG2.SaveProgress();

            gameObject.SetActive(false);

            _mapService.UpdateLevelButtons();
        }
    }
}