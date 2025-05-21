using UnityEngine;
using YG;

public class SkinPacksSaveSystem : SaveSystem
{
    [SerializeField] private PackShop _packShop;

    public override void Load()
    {
        if (YG2.saves.equippedSkins.Count == 0 && YG2.saves.availableSkins.Count == 0)
            _packShop.SetDefaultSkins();

        _packShop.EquipAllEquippedSkins();
        _packShop.SwipeFaction(default);
    }

    public override void LoadLocal()
    {          
        _packShop.SetDefaultSkins();

        _packShop.EquipAllEquippedSkins();
        _packShop.SwipeFaction(default);
    }

    public override void Save()
    {
        _packShop.EquipAllEquippedSkins();

        YG2.SaveProgress();
    }
}
