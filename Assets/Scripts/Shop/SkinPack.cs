using System.Collections.Generic;
using Units;
using UnityEngine;

[CreateAssetMenu(fileName = "SkinPack", menuName = "Scriptable Objects/Skins")]
public class SkinPack : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private Faction _faction;
    [SerializeField] private List<UnitMenuView> _skins;

    public string Name => _name;
    public Faction Faction => _faction;
    public IReadOnlyList<UnitMenuView> Skins => _skins;
}
