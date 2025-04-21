using System;
using System.Collections.Generic;
using Units;
using UnityEngine;

public class PackShop : MonoBehaviour
{
    [SerializeField] private List<SkinPack> _skinPacks;

    private Faction _currentFaction;

    public event Action<Faction> FactionSwiped;

    public IReadOnlyList<SkinPack> SkinPacks => _skinPacks;
    public Faction CurrentFaction => _currentFaction;

    public void SwipeFaction(int index)
    {
        int factionLength = Enum.GetValues(typeof(Faction)).Length - 1;
        int tempIndex = (int)(_currentFaction + index);

        if (tempIndex < 0 || tempIndex > factionLength)
            return;

        _currentFaction += index;

        FactionSwiped?.Invoke(_currentFaction);
    }

    public void SwipePacks(int index)
    {

    }
}
