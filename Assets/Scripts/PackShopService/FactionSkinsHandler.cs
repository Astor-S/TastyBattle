using System;
using System.Collections.Generic;
using Units;
using UnityEngine;

namespace PackShopService
{
    public class FactionSkinsHandler : MonoBehaviour
    {
        private const int FirstCampaign = 0;
        private const int CorrectionShift = 1;

        [SerializeField] private PackShop _packShop;

        private List<SkinPack> _currentFactionSkins = new List<SkinPack>();
        private int _currentFaction;
        private int _skinPackIndex;

        public event Action<SkinPack> SkinPackSwiped;

        public SkinPack CurrentSkinPack => _currentFactionSkins[_skinPackIndex];

        public void OnEnable() =>
            _packShop.FactionIdSwiped += SwipeFaction;

        public void OnDisable() =>
            _packShop.FactionIdSwiped -= SwipeFaction;

        public void SwipeFaction(int index)
        {
            Swipe(index, Enum.GetValues(typeof(Faction)).Length, ref _currentFaction);

            SetAllFactionSkins();

            SkinPackSwiped?.Invoke(GetFirstFactionSkin());
            _packShop.SetCurrentFactionSkin(GetFirstFactionSkin());

            _skinPackIndex = default;

            _packShop.CheckEquipment();
        }

        public void SwipePacks(int index)
        {
            Swipe(index, _currentFactionSkins.Count, ref _skinPackIndex);

            SkinPackSwiped?.Invoke(CurrentSkinPack);
            _packShop.SetCurrentFactionSkin(CurrentSkinPack);

            _packShop.CheckEquipment();
        }

        public SkinPack GetFirstFactionSkin() =>
            _currentFactionSkins[0];

        private void SetAllFactionSkins()
        {
            _currentFactionSkins.Clear();

            foreach (SkinPack skinPack in _packShop.DefaultSkins)
                if ((int)skinPack.Faction == _currentFaction)
                    _currentFactionSkins.Add(skinPack);

            foreach (SkinPack skinPack in _packShop.OtherSkins)
                if ((int)skinPack.Faction == _currentFaction)
                    _currentFactionSkins.Add(skinPack);

            _packShop.SetFactionSkins(_currentFactionSkins);
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
}