using UnityEngine;
using YG;

public class SkinPacksSaveSystem : SaveSystem
{
    [SerializeField] private PackShop _packShop;

    public override void Load()
    {
        YG2.saves.skinPacks.Clear();

        if (YG2.saves.skinPacks.Count == 0)
        {
            YG2.saves.skinPacks.AddRange(_packShop.DefaultSkins);
            YG2.saves.skinPacks.AddRange(_packShop.OtherSkins);
        }

        _packShop.SwipeFaction(default);
        _packShop.SwipePacks(default);

        if (YG2.saves.isFirstLaunch)
#if UNITY_EDITOR
            _packShop.EquipDefaultSkins();
#endif

        _packShop.EquipAllEquippedSkins();
        _packShop.CheckEquipment();
    }

    public override void Save()
    {
        _packShop.EquipAllEquippedSkins();

        YG2.SaveProgress();
    }
}
