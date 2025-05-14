using System;
using System.Collections.Generic;
using Units;
using UnityEngine;

public class PackShop : MonoBehaviour
{
    private const int FirstCampaign = 0;
    private const int CorrectionShift = 1;

    [SerializeField] private List<SkinPack> _defaultSkins;
    [SerializeField] private List<SkinPack> _otherSkins;
    [SerializeField] private List<FactionUnits> _factionUnits;

    private List<SkinPack> _allSkinPacks = new();
    private List<SkinPack> _currentFactionSkins = new();
    private int _currentFaction;
    private int _skinPackIndex;

    public event Action<SkinPack> SkinPackSwiped;
    public event Action<bool> IsEquipped;

    public IReadOnlyList<SkinPack> AllSkinPacks => _allSkinPacks;

    private void OnEnable()
    {
        if (_allSkinPacks.Count == 0)
        {
            _allSkinPacks.AddRange(_defaultSkins);
            _allSkinPacks.AddRange(_otherSkins);
        }

        SwipeFaction(default);
        SwipePacks(default);

        CheckEquipment();
        EquipAllEquippedSkins();
        //EquipDefaultSkins();        
    }

    public void SetSkins(List<SkinPack> skinPacks) =>
        _allSkinPacks = skinPacks;

    public void SwipeFaction(int index)
    {
        Swipe(index, Enum.GetValues(typeof(Faction)).Length, ref _currentFaction);

        SetAllFactionSkins();

        SkinPackSwiped?.Invoke(GetFirstFactionSkin());

        _skinPackIndex = default;

        CheckEquipment();
    }

    public void SwipePacks(int index)
    {
        Swipe(index, _currentFactionSkins.Count, ref _skinPackIndex);

        SkinPackSwiped?.Invoke(_currentFactionSkins[_skinPackIndex]);

        CheckEquipment();
    }

    public void Equip()
    {
        SkinPack currentPack = _currentFactionSkins[_skinPackIndex];
        int index = 0;

        if (currentPack.IsAvailable && currentPack.IsEquipped == false)
        {
            foreach (FactionUnits factionUnit in _factionUnits)
            {
                if (factionUnit.Dictionary[BattleRole.Melee].Faction == currentPack.Faction)
                {
                    foreach (UnitPresenter presenter in factionUnit.Dictionary.Values)
                        presenter.GetComponentInChildren<SkinnedMeshRenderer>().material = currentPack.Skins[index++];

                    foreach (SkinPack skinPack in _currentFactionSkins)
                    {
                        if (skinPack == currentPack)
                            continue;

                        skinPack.Unequip();
                    }

                    currentPack.Equip();
                }
            }
        }
    }

    public void EquipAllEquippedSkins()
    {
        int index = 0;

        Debug.Log(_allSkinPacks.Count);

        foreach (SkinPack skin in _allSkinPacks)
        {
            if (skin.IsEquipped)
            {
                foreach (FactionUnits factionUnit in _factionUnits)
                {
                    if (factionUnit.Dictionary[BattleRole.Melee].Faction == skin.Faction)
                    {
                        foreach (UnitPresenter presenter in factionUnit.Dictionary.Values)
                            presenter.GetComponentInChildren<SkinnedMeshRenderer>().material = skin.Skins[index++];

                        index = 0;
                        break;
                    }
                }
            }
        }
    }

    public SkinPack GetFirstFactionSkin() =>
            _currentFactionSkins[0];

    private void CheckEquipment() =>
        IsEquipped?.Invoke(_currentFactionSkins[_skinPackIndex].IsEquipped);

    //private void EquipDefaultSkins()
    //{
    //    foreach (SkinPack skin in _defaultSkins)
    //        if (skin.IsEquipped == false)
    //            skin.Equip();

    //    foreach (SkinPack skin in _otherSkins)
    //        if (skin.IsEquipped)
    //            skin.Unequip();

    //    CheckEquipment();
    //}

    private void SetAllFactionSkins()
    {
        _currentFactionSkins.Clear();

        foreach (SkinPack skinPack in _allSkinPacks)
            if ((int)skinPack.Faction == _currentFaction)
                _currentFactionSkins.Add(skinPack);
    }

    private void Swipe(int direction, int count, ref int currentIndex)
    {
        int tempIndex = currentIndex + direction;

        if (tempIndex < FirstCampaign)
            tempIndex = count - CorrectionShift;
        else if (tempIndex > count - CorrectionShift)
            tempIndex = FirstCampaign;

        currentIndex = tempIndex;
    }
}
