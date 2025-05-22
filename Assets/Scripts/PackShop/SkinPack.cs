using System.Collections.Generic;
using Units;
using UnityEngine;

[CreateAssetMenu(fileName = "SkinPack", menuName = "Scriptable Objects/Skins")]
public class SkinPack : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private string _enName;
    [SerializeField] private string _trName;
    [SerializeField] private int _id;
    [SerializeField] private Faction _faction;
    [SerializeField] private PurchaseType _purchaseType;
    [SerializeField] private int _price;
    [SerializeField] private List<Material> _skins;
    [SerializeField] private List<UnitModelView> _previews;

    private Dictionary<string, string> _languageNames = new();

    public int Id => _id;
    public Faction Faction => _faction;
    public PurchaseType PurchaseType => _purchaseType;
    public IReadOnlyList<Material> Skins => _skins;
    public IReadOnlyDictionary<string, string> LanguageNames => _languageNames;
    public List<UnitModelView> Previews => _previews;
    public int Price => _price;

    //TODO: Magic values
    private void OnValidate()
    {
        if (_languageNames.Count > 0)
            return;

        _languageNames.Add("ru", _name);
        _languageNames.Add("en", _enName);
        _languageNames.Add("tr", _trName);
    }

    //TODO: Magic values
    private void Awake()
    {
        if (_languageNames.Count > 0)
            return;

        _languageNames.Add("ru", _name);
        _languageNames.Add("en", _enName);
        _languageNames.Add("tr", _trName);
    }
}