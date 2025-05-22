using PlayerPrefs = RedefineYG.PlayerPrefs;
using UnityEngine;
using YG;
using System.Collections.Generic;

public class SkinPacksSaveSystem : SaveSystem
{
    private const string EquippedKey = "equipped";
    private const string AvailableKey = "available";

    [SerializeField] private PackShop _packShop;

    private List<int> _equippedIds = new();
    private List<int> _availableIds = new();

    private void OnEnable() =>
        _packShop.OnEquipped += Save;

    private void OnDisable() =>
        _packShop.OnEquipped -= Save;

    public override void Load()
    {
        if (YG2.saves.equippedSkins.Count == 0 && YG2.saves.availableSkins.Count == 0)
            _packShop.SetDefault();
        else
            _packShop.SetSkins(YG2.saves.equippedSkins, YG2.saves.availableSkins);
    }

    public override void LoadLocal()
    {
        if (PlayerPrefs.HasKey(EquippedKey) == false && PlayerPrefs.HasKey(AvailableKey) == false)
            _packShop.SetDefault();
        else
            _packShop.SetSkinsById(PlayerPrefs.GetString(EquippedKey), PlayerPrefs.GetString(AvailableKey));
    }

    public override void Save()
    {
        string equipped = default;
        string available = default;

        foreach (SkinPack skin in _packShop.EquippedSkinPacks)
            equipped += skin.Id;

        foreach (SkinPack skin in _packShop.AvailableSkinPacks)
            available += skin.Id;

        PlayerPrefs.SetString(EquippedKey, equipped);
        PlayerPrefs.SetString(AvailableKey, available);

        PlayerPrefs.Save();

        YG2.saves.equippedSkins = (List<SkinPack>)_packShop.EquippedSkinPacks;
        YG2.saves.availableSkins = (List<SkinPack>)_packShop.AvailableSkinPacks;

        YG2.SaveProgress();
    }
}
