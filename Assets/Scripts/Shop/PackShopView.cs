using System;
using System.Collections.Generic;
using TMPro;
using Units;
using UnityEngine;

public class PackShopView : MonoBehaviour
{
    [SerializeField] private PackShop _packShop;
    [SerializeField] private List<Transform> _containers;
    [SerializeField] private TextMeshProUGUI _packNameField;

    private void Awake() =>
        ShowSkinPack();

    private void OnEnable()
    {
        _packShop.FactionSwiped += ShowSkinPack;
        _packShop.SkinPackSwiped += ShowSkinPack;
    }

    private void OnDisable()
    {
        _packShop.FactionSwiped -= ShowSkinPack;
        _packShop.SkinPackSwiped -= ShowSkinPack;
    }

    private void ShowSkinPack(SkinPack skinPack) => 
        PlaceSkin(skinPack);

    private void ShowSkinPack() => 
        PlaceSkin(_packShop.GetFirstSkinPack());

    private void PlaceSkin(SkinPack skinPack)
    {
        ClearContainers();

        _packNameField.text = skinPack.Name;

        for (int i = 0; i < _containers.Count; i++)
            Instantiate(skinPack.Skins[i], _containers[i]);
    }

    private void ClearContainers()
    {
        for (int i = 0; i < _containers.Count; i++)
            if (_containers[i].childCount > 0)
                if (_containers[i].GetChild(0).gameObject != null)
                    Destroy(_containers[i].GetChild(0).gameObject);
    }
}
