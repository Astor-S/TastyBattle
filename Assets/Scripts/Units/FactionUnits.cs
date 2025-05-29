using System.Collections.Generic;
using Units;
using UnityEngine;

[CreateAssetMenu(fileName = "FactionUnitsSetup", menuName = "Scriptable Objects/FactionUnitsSetup")]
public class FactionUnits : ScriptableObject
{
    [SerializeField] private UnitPresenter _meleeUnit = null;
    [SerializeField] private UnitPresenter _rangeUnit = null;
    [SerializeField] private UnitPresenter _tankUnit = null;
    [SerializeField] private UnitPresenter _siegeUnit = null;

    private Dictionary<BattleRole, UnitPresenter> _dictionary;

    public IReadOnlyDictionary<BattleRole, UnitPresenter> Dictionary => _dictionary;

    private void Awake() =>
        Init();

    private void OnValidate() =>
        Init();

    private void Init()
    {
        _dictionary = new Dictionary<BattleRole, UnitPresenter>()
        {
            { BattleRole.Melee, _meleeUnit },
            { BattleRole.Range, _rangeUnit },
            { BattleRole.Tank, _tankUnit },
            { BattleRole.Siege, _siegeUnit },
        };
    }
}
