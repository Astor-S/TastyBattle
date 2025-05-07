using System;
using UnityEngine;
using UnityEngine.UI;

public class PackShopTransacting : MonoBehaviour
{
    [SerializeField] private PackShop _packShop;
    [SerializeField] private Button _purchaseButton;
    [SerializeField] private Button _equipButton;

    public event Action<bool> IsAvailable;

    private void OnEnable() =>
        _packShop.SkinPackSwiped += CheckAccess;

    private void OnDisable() =>
        _packShop.SkinPackSwiped -= CheckAccess;

    private void CheckAccess(SkinPack skinPack)
    {
        _purchaseButton.gameObject.SetActive(skinPack.IsAvailable == false);
        _equipButton.gameObject.SetActive(skinPack.IsAvailable);

        IsAvailable.Invoke(skinPack.IsAvailable);
    }
}
