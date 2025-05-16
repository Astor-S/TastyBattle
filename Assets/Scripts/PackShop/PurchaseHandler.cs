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
    private const string RuAdCondition = "Watch ad and take this skin";
    private const string EnAdCondition = "Посмотрите рекламу и заберите этот скин";
    private const string TrAdCondition = "Reklamı izleyin ve bu cildi alın";

    private const string RuPriceCondition = "Price: ";
    private const string EnPriceCondition = "Цена: ";
    private const string TrPriceCondition = "Fiyat: ";

    private const string RuLevelPassCondition = "Complete the mushroom campaign to get this skin";
    private const string EnLevelPassCondition = "Завершите грибную кампанию, чтобы получить этот скин";
    private const string TrLevelPassCondition = "Bu cildi elde etmek için mantar kampanyasını tamamlayın";

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
        if (_languageAdCondition.Count == 0)
        {
            _languageAdCondition.Add("ru", RuAdCondition);
            _languageAdCondition.Add("en", EnAdCondition);
            _languageAdCondition.Add("tr", TrAdCondition);
        }
        else if (_languagePriceCondition.Count == 0)
        {
            _languagePriceCondition.Add("ru", RuPriceCondition);
            _languagePriceCondition.Add("en", EnPriceCondition);
            _languagePriceCondition.Add("tr", TrPriceCondition);
        }
        else if (_languageLevelCondition.Count == 0)
        {
            _languageLevelCondition.Add("ru", RuLevelPassCondition);
            _languageLevelCondition.Add("en", EnLevelPassCondition);
            _languageLevelCondition.Add("tr", TrLevelPassCondition);
        }
    }

    private void OnDisable()
    {
        _shop.SkinPackSwiped -= SetState;
        _button.onClick.RemoveAllListeners();
    }

    private void SetState(SkinPack skin)
    {
        _button.onClick.RemoveAllListeners();

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

    private void PrapareButton(UnityAction action, string condition)
    {
        _button.onClick.AddListener(action);
        _description.text = condition;
    }

    private void CheckLevelPassing()
    {
        if (YG2.saves.isMushroomCampaignCompleted)
        {
            _shop.CurrentSkinPack.Purchase();

            YG2.SaveProgress();

            HideButton();
        }
    }

    private void SpendCoins()
    {
        int price = _shop.CurrentSkinPack.Price;

        if (YG2.saves.balanceMoney >= price)
        {
            YG2.saves.balanceMoney -= price;
            YG2.SaveProgress();

            _shop.CurrentSkinPack.Purchase();

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
        _shop.CurrentSkinPack.Purchase();
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
