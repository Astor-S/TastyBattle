using System;
using System.Collections.Generic;
using Units;
using UnityEngine;

public class PackShop : MonoBehaviour
{
    [SerializeField] private List<SkinPack> _defaultSkins;
    [SerializeField] private List<SkinPack> _otherSkins;
    [SerializeField] private List<FactionUnits> _factionUnits;

    private int _currentFaction;
    private int _skinPackIndex;
    private List<SkinPack> _allSkinPacks = new();
    private List<SkinPack> _currentFactionSkins = new();

    public event Action<SkinPack> SkinPackSwiped;

    private void OnEnable()
    {
        _allSkinPacks.AddRange(_defaultSkins);
        _allSkinPacks.AddRange(_otherSkins);

        SwipePacks(default);
    }        

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

        foreach (SkinPack skinPack in _allSkinPacks)
            if ((int)skinPack.Faction == _currentFaction)
                currentFactionSkins.Add(skinPack);

        return currentFactionSkins;
    }

    private void Swipe(int direction, int count, ref int currentIndex)
    {
        int tempIndex = currentIndex + direction;

        if (tempIndex < 0 || tempIndex > count - 1)
            return;

        currentIndex = tempIndex;
    }

    public void Equip()
    {
        SkinPack currentPack = _currentFactionSkins[_skinPackIndex];
        int index = 0;

        if (currentPack.IsAvailable)
            foreach (FactionUnits factionUnit in _factionUnits)
                if (factionUnit.Dictionary[BattleRole.Melee].Faction == currentPack.Faction)
                    foreach (UnitPresenter presenter in factionUnit.Dictionary.Values)
                        presenter.GetComponentInChildren<SkinnedMeshRenderer>().material = currentPack.Skins[index++];
    }
}
