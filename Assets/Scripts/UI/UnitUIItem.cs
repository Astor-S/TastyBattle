using System;
using Units;
using UnityEngine;
using UnityEngine.UI;

public class UnitUIItem : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private Faction _faction;
    [SerializeField] private BattleRole _battleRole;
    [SerializeField] private int _cost;

    public event Action<Faction, BattleRole, int> UnitOrdered;

    private void OnEnable()
    {
        _button.onClick.AddListener(OrderUnit);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OrderUnit);
    }

    private void OrderUnit()
    {
        UnitOrdered?.Invoke(_faction, _battleRole, _cost);
    }
}
