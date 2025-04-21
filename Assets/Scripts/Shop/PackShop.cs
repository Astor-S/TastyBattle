using System;
using System.Collections.Generic;
using Units;
using UnityEngine;

public class PackShop : MonoBehaviour
{
    [SerializeField] private List<SkinPack> _skinPacks;

    private Faction _currentFaction;
    private List<SkinPack> _currentFactionSkins = new();
    private int _skinPackIndex;

    public event Action FactionSwiped;
    public event Action<SkinPack> SkinPackSwiped;

    public IReadOnlyList<SkinPack> SkinPacks => _skinPacks;

    public void SwipeFaction(int index) //дубляж кода
    {
        int factionLength = Enum.GetValues(typeof(Faction)).Length - 1;
        int tempIndex = (int)(_currentFaction + index);

        if (tempIndex < 0 || tempIndex > factionLength)
            return;

        _currentFaction += index;

        _skinPackIndex = default;

        FactionSwiped?.Invoke();
    }

    public void SwipePacks(int index) //дубляж кода
    {
        int skinPacksCount = _currentFactionSkins.Count;
        int tempIndex = _skinPackIndex + index;

        if (tempIndex < 0 || tempIndex > skinPacksCount - 1)
            return;

        _skinPackIndex += index;

        SkinPackSwiped?.Invoke(_currentFactionSkins[_skinPackIndex]);
    }

    public SkinPack GetFirstSkinPack()
    {
        _currentFactionSkins = GetAllPackSkins();

        return _currentFactionSkins[0];
    }

    private List<SkinPack> GetAllPackSkins()
    {
        List<SkinPack> currentFactionSkins = new();

        foreach (SkinPack skinPack in _skinPacks)
            if (skinPack.Faction == _currentFaction)
                currentFactionSkins.Add(skinPack);

        return currentFactionSkins;
    }
}
