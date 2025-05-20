using UnityEngine;
using YG;

public class SkinPacksSaveSystem : SaveSystem
{
    [SerializeField] private PackShop _packShop;

    public override void Load()
    {
        if (YG2.saves.availableSkinPacks.Count == 0)
        {
            foreach (SkinPack skin in _packShop.DefaultSkins)
                YG2.saves.availableSkinPacks.Add(skin, true);

            foreach (SkinPack skin in _packShop.OtherSkins)
                YG2.saves.availableSkinPacks.Add(skin, false);
        }

        _packShop.SwipeFaction(default);

#if UNITY_EDITOR == false
        if (YG2.saves.isFirstLaunch)
#endif
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
