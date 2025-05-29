using GameService;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using YG;

namespace PackShopService
{
    public class PurchaseHandler : MonoBehaviour
    {
        [SerializeField] private TextTranslation _adCondition;
        [SerializeField] private TextTranslation _priceCondition;
        [SerializeField] private TextTranslation _levelPassCondition;
        [SerializeField] private Button _button;
        [SerializeField] private FactionSkinsHandler _factionSkinsHandler;
        [SerializeField] private TextMeshProUGUI _description;
        [SerializeField] private PackShop _packShop;
        [SerializeField] private RewardAdService _rewardAdService;
        [SerializeField] private Transform _lockPanel;

        public event Action TransactionCompleted;

        private void OnEnable() =>
            _factionSkinsHandler.SkinPackSwiped += SetState;

        private void OnDisable()
        {
            _factionSkinsHandler.SkinPackSwiped -= SetState;
            _button.onClick.RemoveAllListeners();
        }

        private void SetState(SkinPack skin)
        {
            _button.onClick.RemoveAllListeners();

            if (_packShop.IsAvailable(skin) == false)
            {
                switch (skin.PurchaseType)
                {
                    case PurchaseType.ByAd:
                        PrapareButton(ShowAdForReward, _adCondition.Dictionary[YG2.lang]);
                        break;
                    case PurchaseType.ByCoins:
                        PrapareButton(SpendCoins, _priceCondition.Dictionary[YG2.lang] + skin.Price);
                        break;
                    case PurchaseType.ByLevelPassing:
                        PrapareButton(CheckLevelPassing, _levelPassCondition.Dictionary[YG2.lang]);
                        break;
                }
            }
        }

        private void PrapareButton(UnityAction action, string condition)
        {
            _button.onClick.AddListener(action);
            _description.text = condition;
        }

        private void CheckLevelPassing()
        {
            if (YG2.saves.isMushroomCampaignCompleted)
            {
                SaveSkinPack();

                HideButton();
            }
        }

        private void SaveSkinPack()
        {
            _packShop.AddAvailableSkin(_factionSkinsHandler.CurrentSkinPack);
            _packShop.Change();
        }

        private void SpendCoins()
        {
            int price = _factionSkinsHandler.CurrentSkinPack.Price;

            if (YG2.saves.balanceMoney >= price)
            {
                YG2.saves.balanceMoney -= price;
                SaveSkinPack();

                TransactionCompleted?.Invoke();

                HideButton();
            }
        }

        private void ShowAdForReward()
        {
            _rewardAdService.SkinReceived += OpenSkin;
            _rewardAdService.ShowRewardAd(_rewardAdService.SkinId);
        }

        private void OpenSkin()
        {
            SaveSkinPack();

            HideButton();

            _rewardAdService.SkinReceived -= OpenSkin;
        }

        private void HideButton()
        {
            _button.onClick.RemoveAllListeners();
            _button.gameObject.SetActive(false);
            _lockPanel.gameObject.SetActive(false);
        }
    }
}