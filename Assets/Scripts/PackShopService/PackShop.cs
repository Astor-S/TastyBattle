using System;
using System.Collections.Generic;
using Units;
using UnityEngine;

namespace PackShopService
{
    public class PackShop : MonoBehaviour
    {
        [SerializeField] private List<SkinPack> _defaultSkins;
        [SerializeField] private List<SkinPack> _otherSkins;
        [SerializeField] private List<FactionUnits> _factionUnits;

        private List<SkinPack> _equippedSkinPacks = new List<SkinPack>();
        private List<SkinPack> _availableSkinPacks = new List<SkinPack>();
        private IReadOnlyList<SkinPack> _factionSkins = new List<SkinPack>();
        private SkinPack _currentSkin;

        public event Action OnEquipped;
        public event Action<bool> IsEquipped;
        public event Action<int> FactionIdSwiped;

        public IReadOnlyList<SkinPack> DefaultSkins => _defaultSkins;
        public IReadOnlyList<SkinPack> OtherSkins => _otherSkins;
        public IReadOnlyList<SkinPack> EquippedSkinPacks => _equippedSkinPacks;
        public IReadOnlyList<SkinPack> AvailableSkinPacks => _availableSkinPacks;

        public bool IsAvailable(SkinPack skin) =>
            _availableSkinPacks.Contains(skin);

        public void AddAvailableSkin(SkinPack skin) =>
            _availableSkinPacks.Add(skin);

        public void SetCurrentFactionSkin(SkinPack skinPack) =>
            _currentSkin = skinPack;

        public void SetFactionSkins(IReadOnlyList<SkinPack> factionSkins) =>
            _factionSkins = factionSkins;

        public void SetSkinsById(ref string equipped, ref string available)
        {
            _equippedSkinPacks.Clear();
            _availableSkinPacks.Clear();

            CheckId(equipped, available);

            foreach (SkinPack skin in _otherSkins)
            {
                CheckId(equipped, skin, _equippedSkinPacks);
                CheckId(available, skin, _availableSkinPacks);
            }

            EquipAllEquippedSkins();
            FactionIdSwiped?.Invoke(default);
        }

        public void SetSkins(List<SkinPack> equipped, List<SkinPack> available)
        {
            _equippedSkinPacks = equipped;
            _availableSkinPacks = available;

            EquipAllEquippedSkins();
            FactionIdSwiped?.Invoke(default);
        }

        public void SetDefault()
        {
            SetDefaultSkins();

            FactionIdSwiped?.Invoke(default);
            EquipAllEquippedSkins();
        }

        public void CheckEquipment() =>
            IsEquipped?.Invoke(_equippedSkinPacks.Contains(_currentSkin));

        public void Equip()
        {
            if (_availableSkinPacks.Contains(_currentSkin) && _equippedSkinPacks.Contains(_currentSkin) == false)
                IsSetMaterials(_currentSkin);

            Change();
        }

        public void Change() =>
            OnEquipped?.Invoke();

        public void EquipAllEquippedSkins()
        {
            foreach (SkinPack skin in _equippedSkinPacks)
                if (IsSetMaterials(skin))
                    break;
        }

        private void CheckId(string equipped, string available)
        {
            foreach (SkinPack skin in _defaultSkins)
            {
                CheckId(equipped, skin, _equippedSkinPacks);
                CheckId(available, skin, _availableSkinPacks);
            }
        }

        private void SetDefaultSkins()
        {
            _equippedSkinPacks.Clear();
            _availableSkinPacks.Clear();

            foreach (SkinPack skin in _defaultSkins)
            {
                _equippedSkinPacks.Add(skin);
                _availableSkinPacks.Add(skin);
            }

            CheckEquipment();
        }

        private void CheckId(string equipped, SkinPack skin, List<SkinPack> skinPacks)
        {
            foreach (char id in equipped)
            {
                if ($"{skin.Id}" == $"{id}")
                {
                    skinPacks.Add(skin);
                    break;
                }
            }
        }

        private bool IsSetMaterials(SkinPack skin, int index = default)
        {
            foreach (FactionUnits factionUnit in _factionUnits)
            {
                if (factionUnit.Dictionary[BattleRole.Melee].Faction == skin.Faction)
                {
                    foreach (UnitPresenter presenter in factionUnit.Dictionary.Values)
                        presenter.GetComponentInChildren<SkinnedMeshRenderer>().material = skin.Skins[index++];

                    foreach (SkinPack skinPack in _factionSkins)
                    {
                        if (skinPack == skin)
                            continue;

                        _equippedSkinPacks.Remove(skinPack);
                    }

                    _equippedSkinPacks.Add(skin);

                    return true;
                }
            }

            return false;
        }
    }
}