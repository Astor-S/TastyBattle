using GameService;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class PurchaseHandler : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private TextMeshProUGUI _description;
    [SerializeField] private PackShop _shop;
    [SerializeField] private RewardAdService _rewardAdService;

    private void OnEnable() =>
        _shop.SkinPackSwiped += SetState;

    private void OnDisable()
    {
        _shop.SkinPackSwiped -= SetState;
        _button.onClick.RemoveAllListeners();
    }

    //public void Purchase()
    //{
    //    SkinPack currentPack = _shop.CurrentSkinPack;

    //    foreach (SkinPack skin in _shop.OtherSkins)
    //    {
    //        if (skin == currentPack)
    //        {
    //            if (skin.PurchaseType == PurchaseType.ByAd)
    //            {
    //                ShowAdForReward();
    //            }
    //            else if (skin.PurchaseType == PurchaseType.ByCoins)
    //            {
    //                if (YG2.saves.balanceMoney >= skin.Price)
    //                {
    //                    YG2.saves.balanceMoney -= skin.Price;
    //                    YG2.SaveProgress();

    //                    skin.Purchase();
    //                }
    //            }
    //            else if (skin.PurchaseType == PurchaseType.ByLevelPassing)
    //            {
    //                //levelLogic
    //            }
    //        }
    //    }
    //}

    private void SetState(SkinPack skin)
    {
        Debug.Log(123);
        _button.onClick.RemoveAllListeners();

        switch (skin.PurchaseType)
        {
            case PurchaseType.ByAd:
                _button.onClick.AddListener(ShowAdForReward);
                _description.text = "Watch ad and take this skin";
                break;
            case PurchaseType.ByCoins:
                _button.onClick.AddListener(SpendCoins);
                _description.text = $"Price: {skin.Price}";
                break;
            case PurchaseType.ByLevelPassing:
                _button.onClick.AddListener(CheckLevelPassing);
                _description.text = "Complete the mushroom campaign to get this skin";
                break;
            case PurchaseType.None:
                _description.text = "None";
                break;
            default:
                _description.text = "null";
                break;
        }
    }

    private void CheckLevelPassing()
    {
        if (YG2.saves.isMushroomCampaignCompleted)
        {
            _shop.CurrentSkinPack.Purchase();

            YG2.saves.isMushroomCampaignCompleted = true;
            YG2.SaveProgress();

            _button.onClick.RemoveAllListeners();
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

            _button.onClick.RemoveAllListeners();
        }
    }

    private void ShowAdForReward()
    {
        _rewardAdService.RewardReceived += OpenSkin;
        _rewardAdService.ShowRewardAd(default);
    }

    private void OpenSkin()
    {
        _shop.CurrentSkinPack.Purchase();
        _rewardAdService.RewardReceived -= OpenSkin;
        _button.onClick.RemoveAllListeners();
    }
}
