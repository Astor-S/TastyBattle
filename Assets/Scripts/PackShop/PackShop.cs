using System;
using System.Collections.Generic;
using Units;
using UnityEngine;

public class PackShop : MonoBehaviour
{
    [SerializeField] private List<SkinPack> _skinPacks;

    private int _currentFaction;
    private List<SkinPack> _currentFactionSkins = new();
    private int _skinPackIndex;

    public event Action<SkinPack> SkinPackSwiped;

    private void Start() =>
        SwipePacks(default);

    public void SwipeFaction(int index)
    {        
        Swipe(index, Enum.GetValues(typeof(Faction)).Length, ref _currentFaction);

        SkinPackSwiped?.Invoke(GetFirstSkinPack());

        _skinPackIndex = default;
    }    

    public void SwipePacks(int index)
    {       
        Swipe(index, _currentFactionSkins.Count, ref _skinPackIndex);

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
            if ((int)skinPack.Faction == _currentFaction)
                currentFactionSkins.Add(skinPack);

        return currentFactionSkins;
    }

    private void Swipe(int extraIndex, int count, ref int currentIndex)
    {
        int tempIndex = currentIndex + extraIndex;

        if (tempIndex < 0 || tempIndex > count - 1)
            return;

        currentIndex = tempIndex;
    }
}
