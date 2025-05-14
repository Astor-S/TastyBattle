using GameService;
using UnityEngine;
using YG;

namespace UI.HomeMenu.ShopMenu
{
    public class AddSkinForADButton : MenuButton
    {
        //[SerializeField] private Skins _skinToAdd;
        [SerializeField] private RewardAdService _rewardAdService;

        private void Start()
        {
            //if (YG2.saves.ownedSkins.Contains(_skinToAdd) == false)
            //    gameObject.SetActive(true);
            //else
            //    gameObject.SetActive(false);
        }

        private void OnEnable()
        {
            _rewardAdService.RewardReceived += AddSkin;
        }

        private void OnDisable()
        {
            _rewardAdService.RewardReceived -= AddSkin;
        }

        //public override void OnButtonClick() =>
        //    _rewardAdService.ShowRewardAd(0);

        private void AddSkin()
        {
            //YG2.saves.ownedSkins.Add(_skinToAdd);
            //YandexGame.SaveProgress();
            gameObject.SetActive(false);
        }
    }
}