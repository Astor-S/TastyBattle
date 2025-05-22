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

    private List<SkinPack> _currentFactionSkins = new();
    private List<SkinPack> _equippedSkinPacks = new();
    private List<SkinPack> _availableSkinPacks = new();
    private int _currentFaction;
    private int _skinPackIndex;

    public event Action<SkinPack> SkinPackSwiped;
    public event Action OnEquipped;
    public event Action<bool> IsEquipped;

    public IReadOnlyList<SkinPack> EquippedSkinPacks => _equippedSkinPacks;
    public IReadOnlyList<SkinPack> AvailableSkinPacks => _availableSkinPacks;
    public SkinPack CurrentSkinPack => _currentFactionSkins[_skinPackIndex];

    public bool IsAvailable(SkinPack skin) => 
        _availableSkinPacks.Contains(skin);
    
    public void AddAvailableSkin(SkinPack skin) => 
        _availableSkinPacks.Add(skin);

    public void SetSkinsById(string equipped, string available)
    {
        _equippedSkinPacks.Clear();
        _availableSkinPacks.Clear();

        foreach (SkinPack skin in _defaultSkins)
        {
            foreach (int id in equipped)
                if (skin.Id == id)
                    _equippedSkinPacks.Add(skin);

            foreach (int id in available)
                if (skin.Id == id)
                    _availableSkinPacks.Add(skin);
        }

        foreach (SkinPack skin in _otherSkins)
        {
            foreach (int id in equipped)
                if (skin.Id == id)
                    _equippedSkinPacks.Add(skin);

            foreach (int id in available)
                if (skin.Id == id)
                    _availableSkinPacks.Add(skin);
        }
    }

    public void SetSkins(List<SkinPack> equipped, List<SkinPack> available)
    {
        _equippedSkinPacks = equipped;
        _availableSkinPacks = available;

        EquipAllEquippedSkins();
        SwipeFaction(default);
    }

    public void SetDefault()
    {
        if (_equippedSkinPacks.Count == 0 && _availableSkinPacks.Count == 0)
            SetDefaultSkins();

        EquipAllEquippedSkins();
        SwipeFaction(default);
    }

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

        SkinPackSwiped?.Invoke(CurrentSkinPack);

        CheckEquipment();
    }

    public void Equip()
    {
        int index = 0;

        if (_availableSkinPacks.Contains(CurrentSkinPack) && _equippedSkinPacks.Contains(CurrentSkinPack) == false)
        {
            foreach (FactionUnits factionUnit in _factionUnits)
            {
                if (factionUnit.Dictionary[BattleRole.Melee].Faction == CurrentSkinPack.Faction)
                {
                    foreach (UnitPresenter presenter in factionUnit.Dictionary.Values)
                        presenter.GetComponentInChildren<SkinnedMeshRenderer>().material = CurrentSkinPack.Skins[index++];

                    foreach (SkinPack skinPack in _currentFactionSkins)
                    {
                        if (skinPack == CurrentSkinPack)
                            continue;

                        _equippedSkinPacks.Remove(skinPack);
                    }

                    _equippedSkinPacks.Add(CurrentSkinPack);
                }
            }
        }

        Change();
    }

    public void Change() => 
        OnEquipped?.Invoke();

    public void EquipAllEquippedSkins()
    {
        int index = 0;

        foreach (SkinPack skin in _equippedSkinPacks)
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

    public SkinPack GetFirstFactionSkin() =>
            _currentFactionSkins[0];

    public void CheckEquipment() =>
        IsEquipped?.Invoke(_equippedSkinPacks.Contains(CurrentSkinPack));

    public void SetDefaultSkins()
    {
        foreach (SkinPack skin in _defaultSkins)
        {
            _equippedSkinPacks.Add(skin);
            _availableSkinPacks.Add(skin);
        }

        CheckEquipment();
    }

    private void SetAllFactionSkins()
    {
        _currentFactionSkins.Clear();

        foreach (SkinPack skinPack in _defaultSkins)
            if ((int)skinPack.Faction == _currentFaction)
                _currentFactionSkins.Add(skinPack);

        foreach (SkinPack skinPack in _otherSkins)
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
