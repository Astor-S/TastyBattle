using UnityEngine;
using YG;

public class SkinPacksSaveSystem : SaveSystem
{
    [SerializeField] private PackShop _packShop;

    public override void Load()
    {
        if (YG2.saves.SkinPacks.Count == 0)
            return;

        _packShop.SetSkins(YG2.saves.SkinPacks);

        Debug.Log(YG2.saves.SkinPacks.Count);
    }

    public override void Save()
    {
        YG2.saves.SkinPacks = (System.Collections.Generic.List<SkinPack>)_packShop.AllSkinPacks;

        YG2.SaveProgress();

        Debug.Log(YG2.saves.SkinPacks.Count);
    }
}
