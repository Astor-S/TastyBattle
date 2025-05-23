using PlayerPrefs = RedefineYG.PlayerPrefs;
using UnityEngine;
using YG;
using System.Collections.Generic;

public class SkinPacksSaveSystem : SaveSystem
{
    private const string EquippedKey = "equipped";
    private const string AvailableKey = "available";

    [SerializeField] private PackShop _packShop;

    private void OnEnable() =>
        _packShop.OnEquipped += Save;

    private void OnDisable() =>
        _packShop.OnEquipped -= Save;

    public override void Load()
    {
        foreach (SkinPack skin in _packShop.DefaultSkins)
        {
            if (YG2.saves.availablePacks.Contains(skin) == false)
            {
                _packShop.SetDefault();
                break;
            }
        }

        if (YG2.saves.equippedPacks.Count == 0 && YG2.saves.availablePacks.Count == 0)
            _packShop.SetDefault();
        else
            _packShop.SetSkins(YG2.saves.equippedPacks, YG2.saves.availablePacks);

        Save();
    }

    public override void LoadLocal()
    {
        if (PlayerPrefs.HasKey(EquippedKey) == false && PlayerPrefs.HasKey(AvailableKey) == false)
        {
            _packShop.SetDefault();
        }
        else
        {
            string equipped = PlayerPrefs.GetString(EquippedKey);
            string available = PlayerPrefs.GetString(AvailableKey);

            _packShop.SetSkinsById(ref equipped, ref available);
        }

        Save();
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

        YG2.saves.equippedPacks = (List<SkinPack>)_packShop.EquippedSkinPacks;
        YG2.saves.availablePacks = (List<SkinPack>)_packShop.AvailableSkinPacks;

        YG2.SaveProgress();
    }
}
