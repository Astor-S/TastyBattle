using System;
using System.Collections.Generic;
using Units;
using UnityEngine;
using YG;

public class PackShop : MonoBehaviour
{
    private const int FirstCampaign = 0;
    private const int CorrectionShift = 1;

    [SerializeField] private List<SkinPack> _defaultSkins;
    [SerializeField] private List<SkinPack> _otherSkins;
    [SerializeField] private List<FactionUnits> _factionUnits;

    private List<SkinPack> _currentFactionSkins = new();
    private int _currentFaction;
    private int _skinPackIndex;

    public event Action<SkinPack> SkinPackSwiped;
    public event Action<bool> IsEquipped;

    public IReadOnlyList<SkinPack> DefaultSkins => _defaultSkins;
    public IReadOnlyList<SkinPack> OtherSkins => _otherSkins;
    public int CurrentSkinPack => _currentFactionSkins[_skinPackIndex].Id;

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

        SkinPackSwiped?.Invoke(GetSkinPack(CurrentSkinPack));

        CheckEquipment();
    }

    public void Equip()
    {
        int index = 0;

        if (YG2.saves.availableSkins.Contains(CurrentSkinPack) && YG2.saves.equippedSkins.Contains(CurrentSkinPack) == false)
        {
            foreach (FactionUnits factionUnit in _factionUnits)
            {
                SkinPack skin = GetSkinPack(CurrentSkinPack);

                if (factionUnit.Dictionary[BattleRole.Melee].Faction == skin.Faction)
                {
                    foreach (UnitPresenter presenter in factionUnit.Dictionary.Values)
                        presenter.GetComponentInChildren<SkinnedMeshRenderer>().material = skin.Skins[index++];

                    foreach (SkinPack skinPack in _currentFactionSkins)
                    {
                        if (skinPack.Id == CurrentSkinPack)
                            continue;

                        YG2.saves.equippedSkins.Remove(skinPack.Id);
                    }

                    YG2.saves.equippedSkins.Add(CurrentSkinPack);
                }
            }
        }

        YG2.SaveProgress();
    }

    public void EquipAllEquippedSkins()
    {
        int index = 0;

        foreach (int skinId in YG2.saves.equippedSkins)
        {
            foreach (FactionUnits factionUnit in _factionUnits)
            {
                SkinPack skinPack = GetSkinPack(skinId);

                if (factionUnit.Dictionary[BattleRole.Melee].Faction == skinPack.Faction)
                {
                    foreach (UnitPresenter presenter in factionUnit.Dictionary.Values)
                        presenter.GetComponentInChildren<SkinnedMeshRenderer>().material = skinPack.Skins[index++];

                    index = 0;
                    break;
                }
            }
        }
    }

    public SkinPack GetFirstFactionSkin() =>
            _currentFactionSkins[0];

    public void CheckEquipment() =>
        IsEquipped?.Invoke(YG2.saves.equippedSkins.Contains(CurrentSkinPack));

    public void SetDefaultSkins()
    {
        YG2.saves.equippedSkins.Clear();
        YG2.saves.availableSkins.Clear();

        foreach (SkinPack skin in _defaultSkins)
        {
            YG2.saves.equippedSkins.Add(skin.Id);
            YG2.saves.availableSkins.Add(skin.Id);
        }

        YG2.SaveProgress();

        CheckEquipment();
    }

    public SkinPack GetSkinPack(int id)
    {
        SkinPack skinPack = _defaultSkins.Find(skin => skin.Id == id);

        if (skinPack == null)
            skinPack = _otherSkins.Find(skin => skin.Id == id);

        return skinPack;
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
