using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PackShopView : MonoBehaviour
{
    [SerializeField] private PackShop _packShop;
    [SerializeField] private List<Transform> _containers;
    [SerializeField] private TextMeshProUGUI _packNameField;
    [SerializeField] private Transform _lockPanel;
    [SerializeField] private Transform _equipMark;
    [SerializeField] private Button _equipButton;
    [SerializeField] private Button _purchaseButton;

    private void OnEnable()
    {
        _packShop.SkinPackSwiped += ShowSkinPack;
        _packShop.IsEquipped += TryShowEquipButton;

        ShowSkinPack(_packShop.GetFirstFactionSkin());
    }

    private void OnDisable()
    {
        _packShop.SkinPackSwiped -= ShowSkinPack;
        _packShop.IsEquipped -= TryShowEquipButton;
    }

    private void TryShowEquipButton(bool isEquipped)
    {
        _equipMark.gameObject.SetActive(isEquipped);
        _equipButton.gameObject.SetActive(isEquipped == false);
    }

    private void ShowSkinPack(SkinPack skinPack) =>
        ShowSkins(skinPack);

    private void ShowSkins(SkinPack skinPack)
    {
        ClearContainers();

        _packNameField.text = skinPack.Name;

        for (int i = 0; i < _containers.Count; i++)
        {
            skinPack.Previews[i].gameObject.GetComponentInChildren<SkinnedMeshRenderer>().material = skinPack.Skins[i];

            Instantiate(skinPack.Previews[i], _containers[i]);
        }

        TryShowLock(skinPack);
    }

    private void ClearContainers()
    {
        for (int i = 0; i < _containers.Count; i++)
            if (_containers[i].childCount > 0)
                if (_containers[i].GetChild(0).gameObject != null)
                    Destroy(_containers[i].GetChild(0).gameObject);
    }

    private void TryShowLock(SkinPack skins)
    {
        _lockPanel.gameObject.SetActive(skins.IsAvailable == false);
        _purchaseButton.gameObject.SetActive(skins.IsAvailable == false);
    }
}
