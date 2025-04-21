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
        ShowFactionSkins(_packShop.CurrentFaction);

    private void OnEnable() =>
        _packShop.FactionSwiped += ShowFactionSkins;

    private void OnDisable() =>
        _packShop.FactionSwiped -= ShowFactionSkins;

    private void ShowFactionSkins(Faction faction)
    {
        foreach (SkinPack skinPack in _packShop.SkinPacks)
        {
            if (skinPack.Faction == faction)
            {
                for (int i = 0; i < _containers.Count; i++)
                    PlaceSkin(i, skinPack);

                break;
            }
        }
    }

    private void PlaceSkin(int i, SkinPack skinPack)
    {
        if (_containers[i].childCount > 0)
            if (_containers[i].GetChild(0).gameObject != null)
                Destroy(_containers[i].GetChild(0).gameObject);

        _packNameField.text = skinPack.Name;

        Instantiate(skinPack.Skins[i], _containers[i]);
    }
}
