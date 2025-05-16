using GameService;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using YG;

public class PurchaseHandler : MonoBehaviour
{
    //TODO: add translation
    private const string AdCondition = "Watch ad and take this skin";
    private const string PriceCondition = "Price: ";
    private const string LevelPassCondition = "Complete the mushroom campaign to get this skin";

    [SerializeField] private Button _button;
    [SerializeField] private TextMeshProUGUI _description;
    [SerializeField] private PackShop _shop;
    [SerializeField] private RewardAdService _rewardAdService;
    [SerializeField] private Transform _lockPanel;

    public event Action TransactionCompleted;

    private void OnEnable() =>
        _shop.SkinPackSwiped += SetState;

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
                PrapareButton(ShowAdForReward, AdCondition);
                break;
            case PurchaseType.ByCoins:
                PrapareButton(SpendCoins, PriceCondition + skin.Price);
                break;
            case PurchaseType.ByLevelPassing:
                PrapareButton(CheckLevelPassing, LevelPassCondition);
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
