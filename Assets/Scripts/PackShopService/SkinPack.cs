using System.Collections.Generic;
using UI.HomeMenu.CampaignMenu;
using Units;
using UnityEngine;

namespace PackShopService
{
    [CreateAssetMenu(fileName = "SkinPack", menuName = "Scriptable Objects/Skins")]
    public class SkinPack : ScriptableObject
    {
        [SerializeField] private TextTranslation _textTranslation;
        [SerializeField] private int _id;
        [SerializeField] private Faction _faction;
        [SerializeField] private PurchaseType _purchaseType;
        [SerializeField] private int _price;
        [SerializeField] private List<Material> _skins;
        [SerializeField] private List<UnitModelView> _previews;

        public TextTranslation TextTranslation => _textTranslation;
        public int Id => _id;
        public Faction Faction => _faction;
        public PurchaseType PurchaseType => _purchaseType;
        public IReadOnlyList<Material> Skins => _skins;
        public List<UnitModelView> Previews => _previews;
        public int Price => _price;
    }
}