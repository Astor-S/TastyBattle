using GameService;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using YG;

public class PurchaseHandler : MonoBehaviour
{
    //TODO: Different logic
    private string RuAdCondition = "Посмотрите рекламу и заберите этот скин";
    private string EnAdCondition = "Watch ad and take this skin";
    private string TrAdCondition = "Reklamı izleyin ve bu cildi alın";

    private string RuPriceCondition = "Цена: ";
    private string EnPriceCondition = "Price: ";
    private string TrPriceCondition = "Fiyat: ";

    private string RuLevelPassCondition = "Завершите грибную кампанию, чтобы получить этот скин";
    private string EnLevelPassCondition = "Complete the mushroom campaign to get this skin";
    private string TrLevelPassCondition = "Bu cildi elde etmek için mantar kampanyasını tamamlayın";

    [SerializeField] private Button _button;
    [SerializeField] private TextMeshProUGUI _description;
    [SerializeField] private PackShop _shop;
    [SerializeField] private RewardAdService _rewardAdService;
    [SerializeField] private Transform _lockPanel;

    private Dictionary<string, string> _languageAdCondition = new();
    private Dictionary<string, string> _languagePriceCondition = new();
    private Dictionary<string, string> _languageLevelCondition = new();

    public event Action TransactionCompleted;

    private void OnEnable()
    {
        _shop.SkinPackSwiped += SetState;

        //TODO: Magic
        _languageAdCondition.Clear();
        _languagePriceCondition.Clear();
        _languageLevelCondition.Clear();

        _languageAdCondition.Add("ru", RuAdCondition);
        _languageAdCondition.Add("en", EnAdCondition);
        _languageAdCondition.Add("tr", TrAdCondition);

        _languagePriceCondition.Add("ru", RuPriceCondition);
        _languagePriceCondition.Add("en", EnPriceCondition);
        _languagePriceCondition.Add("tr", TrPriceCondition);

        _languageLevelCondition.Add("ru", RuLevelPassCondition);
        _languageLevelCondition.Add("en", EnLevelPassCondition);
        _languageLevelCondition.Add("tr", TrLevelPassCondition);

    }

    private void OnDisable()
    {
        _shop.SkinPackSwiped -= SetState;
        _button.onClick.RemoveAllListeners();
    }

    private void SetState(SkinPack skin)
    {
        _button.onClick.RemoveAllListeners();

        if (YG2.saves.availableSkinPacks[skin] == false)
        {
            switch (skin.PurchaseType)
            {
                case PurchaseType.ByAd:
                    PrapareButton(ShowAdForReward, _languageAdCondition[YG2.lang]);
                    break;
                case PurchaseType.ByCoins:
                    PrapareButton(SpendCoins, _languagePriceCondition[YG2.lang] + skin.Price);
                    break;
                case PurchaseType.ByLevelPassing:
                    PrapareButton(CheckLevelPassing, _languageLevelCondition[YG2.lang]);
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
        YG2.saves.availableSkinPacks[_shop.CurrentSkinPack] = true;
        YG2.SaveProgress();
    }

    private void SpendCoins()
    {
        int price = _shop.CurrentSkinPack.Price;

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

        _rewardAdService.SkinReceived -= OpenSkin;

        HideButton();
    }

    private void HideButton()
    {
        _button.onClick.RemoveAllListeners();
        _button.gameObject.SetActive(false);
        _lockPanel.gameObject.SetActive(false);
    }
}
