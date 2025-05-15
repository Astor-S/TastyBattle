using System.Collections.Generic;
using Units;
using UnityEngine;

[CreateAssetMenu(fileName = "SkinPack", menuName = "Scriptable Objects/Skins")]
public class SkinPack : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private Faction _faction;
    [SerializeField] private PurchaseType _purchaseType;
    [SerializeField] private List<Material> _skins;
    [SerializeField] private bool _isAvailable;
    [SerializeField] private bool _isEquipped;
    [SerializeField] private int _price;
    [SerializeField] private List<UnitModelView> _previews;

    public string Name => _name;
    public Faction Faction => _faction;
    public PurchaseType PurchaseType => _purchaseType;
    public IReadOnlyList<Material> Skins => _skins;
    public bool IsAvailable => _isAvailable;
    public bool IsEquipped => _isEquipped;
    public List<UnitModelView> Previews => _previews;
    public int Price => _price;

    public void Purchase() => 
        _isAvailable = true;

    public void Equip() => 
        _isEquipped = true;

    public void Unequip() => 
        _isEquipped = false;
}
