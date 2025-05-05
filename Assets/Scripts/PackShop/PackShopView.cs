using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PackShopView : MonoBehaviour
{
    [SerializeField] private PackShop _packShop;
    [SerializeField] private PackShopTransacting _packShopTransacting;
    [SerializeField] private List<Transform> _containers;
    [SerializeField] private TextMeshProUGUI _packNameField;
    [SerializeField] private Transform _lockPanel;

    private void Start() => 
        ShowSkinPack(_packShop.GetFirstSkinPack());

    private void OnEnable()
    {
        _packShop.SkinPackSwiped += ShowSkinPack;
        _packShopTransacting.IsAvailable += ShowLock;
    }

    private void OnDisable()
    {
        _packShop.SkinPackSwiped -= ShowSkinPack;
        _packShopTransacting.IsAvailable -= ShowLock;
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
    }

    private void ClearContainers()
    {
        for (int i = 0; i < _containers.Count; i++)
            if (_containers[i].childCount > 0)
                if (_containers[i].GetChild(0).gameObject != null)
                    Destroy(_containers[i].GetChild(0).gameObject);
    }

    private void ShowLock(bool isAvailable) =>
        _lockPanel.gameObject.SetActive(isAvailable == false);
}
