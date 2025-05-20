using UnityEngine;
using YG;

public class SkinPacksSaveSystem : SaveSystem
{
    [SerializeField] private PackShop _packShop;

    public override void Load()
    {
        if (YG2.saves.skinPacks.Count == 0)
        {
            foreach (SkinPack skin in _packShop.DefaultSkins)
                YG2.saves.skinPacks.Add(skin);

            foreach (SkinPack skin in _packShop.OtherSkins)
                YG2.saves.skinPacks.Add(skin);

            YG2.SaveProgress();
        }

        _packShop.SwipeFaction(default);

        if (YG2.saves.isFirstLaunch)
            _packShop.EquipDefaultSkins();

        _packShop.EquipAllEquippedSkins();
        _packShop.CheckEquipment();
    }

    public override void Save()
    {
        _packShop.EquipAllEquippedSkins();

        YG2.SaveProgress();
    }
}
