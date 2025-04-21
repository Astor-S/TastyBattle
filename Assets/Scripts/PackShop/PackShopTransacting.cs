using System;
using UnityEngine;
using UnityEngine.UI;

public class PackShopTransacting : MonoBehaviour
{
    [SerializeField] private PackShop _packShop;
    [SerializeField] private Button _purchaseButton;
    [SerializeField] private Button _equipButton;

    public void OnEnable()
    {
        _packShop.SkinPackSwiped += CheckAccess;
    }    

    private void OnDisable()
    {
        _packShop.SkinPackSwiped -= CheckAccess;
    }
    
    private void CheckAccess(SkinPack pack)
    {
        throw new NotImplementedException();
    }
}
