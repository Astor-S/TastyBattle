using UnityEngine;
using YG;
using System.Collections.Generic;
using System.IO;

public class SkinPacksSaveSystem : SaveSystem
{
    [SerializeField] private PackShop _packShop;

    private List<int> _equippedIds = new();
    private List<int> _availableIds = new();

    private void OnEnable() =>
        _packShop.OnEquipped += Save;

    private void OnDisable() =>
        _packShop.OnEquipped -= Save;

    public override void Load()
    {
        Debug.Log("Cloud load");

        if (YG2.saves.equippedSkins.Count == 0 && YG2.saves.availableSkins.Count == 0)
            _packShop.SetDefault();
        else
            _packShop.SetSkins(YG2.saves.equippedSkins, YG2.saves.availableSkins);
    }

    public override void LoadLocal()
    {
        Debug.Log("Local load");

        SkinPacksSaveData skinPacksSaveData = GetSaveData();

        if (skinPacksSaveData != null)
            _packShop.SetSkins(skinPacksSaveData.equippedSkinPacks, skinPacksSaveData.availableSkinPacks);
        else
            _packShop.SetDefault();
    }

    public override void Save()
    {
        SkinPacksSaveData data = new()
        {
            equippedSkinPacks = (List<SkinPack>)_packShop.EquippedSkinPacks,
            availableSkinPacks = (List<SkinPack>)_packShop.AvailableSkinPacks
        };

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.dataPath + "/SkinSave.json", json);

        YG2.saves.equippedSkins = (List<SkinPack>)_packShop.EquippedSkinPacks;
        YG2.saves.availableSkins = (List<SkinPack>)_packShop.AvailableSkinPacks;

        YG2.SaveProgress();
    }

    private SkinPacksSaveData GetSaveData()
    {
        string path = Application.dataPath + "/SkinSave.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            return JsonUtility.FromJson<SkinPacksSaveData>(json);
        }

        return null;
    }
}
