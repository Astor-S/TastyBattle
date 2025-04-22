using System.Collections.Generic;
using Units;
using UnityEngine;

[CreateAssetMenu(fileName = "SkinPack", menuName = "Scriptable Objects/Skins")]
public class SkinPack : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private Faction _faction;
    [SerializeField] private List<UnitModelView> _skins;
    [SerializeField] private bool _isAvailable;

    public string Name => _name;
    public Faction Faction => _faction;
    public IReadOnlyList<UnitModelView> Skins => _skins;
    public bool IsAvailable => _isAvailable;
}
