using System.Collections.Generic;
using Units;
using UnityEngine;

[CreateAssetMenu(fileName = "SkinPack", menuName = "Scriptable Objects/Skins")]
public class SkinPack : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private Faction _faction;
    [SerializeField] private List<Material> _skins;
    [SerializeField] private bool _isAvailable;
    [SerializeField] private List<UnitModelView> _previews;

    public string Name => _name;
    public Faction Faction => _faction;
    public IReadOnlyList<Material> Skins => _skins;
    public bool IsAvailable => _isAvailable;
    public List<UnitModelView> Previews => _previews;
}
