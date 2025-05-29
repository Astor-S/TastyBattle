using System.Collections.Generic;
using TMPro;
using UI.HomeMenu.CampaignMenu;
using UnityEngine;
using UnityEngine.UI;
using YG;

namespace PackShopService
{
    public class PackShopView : MonoBehaviour
    {
        [SerializeField] private PackShop _packShop;
        [SerializeField] private FactionSkinsHandler _factionSkinsHandler;
        [SerializeField] private List<Transform> _containers;
        [SerializeField] private TextMeshProUGUI _packNameField;
        [SerializeField] private Transform _lockPanel;
        [SerializeField] private Transform _equipMark;
        [SerializeField] private Button _equipButton;
        [SerializeField] private Button _purchaseButton;

        private void OnEnable()
        {
            _factionSkinsHandler.SkinPackSwiped += ShowSkinPack;
            _packShop.IsEquipped += TryShowEquipButton;

            ClearContainers();
            _factionSkinsHandler.SwipeFaction(default);
            ShowSkinPack(_factionSkinsHandler.GetFirstFactionSkin());
        }

        private void OnDisable()
        {
            _factionSkinsHandler.SkinPackSwiped -= ShowSkinPack;
            _packShop.IsEquipped -= TryShowEquipButton;

            ClearContainers();
        }

        private void ShowSkinPack(SkinPack skinPack) =>
            ShowSkins(skinPack);

        private void ShowSkins(SkinPack skinPack)
        {
            ClearContainers();

            _packNameField.text = skinPack.TextTranslation.Dictionary[YG2.lang];

            for (int i = 0; i < _containers.Count; i++)
            {
                UnitModelView skin = Instantiate(skinPack.Previews[i], _containers[i]);

                skin.gameObject.GetComponentInChildren<SkinnedMeshRenderer>().material = skinPack.Skins[i];
            }

            TryShowLock(_packShop.IsAvailable(skinPack));
        }

        private void ClearContainers()
        {
            for (int i = 0; i < _containers.Count; i++)
                if (_containers[i].childCount > 0)
                    if (_containers[i].GetChild(0).gameObject != null)
                        Destroy(_containers[i].GetChild(0).gameObject);
        }

        private void TryShowEquipButton(bool isEquipped)
        {
            _equipMark.gameObject.SetActive(isEquipped);
            _equipButton.gameObject.SetActive(isEquipped == false);
        }

        private void TryShowLock(bool isAvailable)
        {
            _lockPanel.gameObject.SetActive(isAvailable == false);
            _purchaseButton.gameObject.SetActive(isAvailable == false);
        }
    }
}