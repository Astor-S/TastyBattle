using Units;
using UnityEngine;

[CreateAssetMenu(fileName="Unit", menuName="Unit", order=51)]
public class UnitStats : ScriptableObject
{
    [SerializeField] private Faction _faction;
    [SerializeField] private BattleRole _battleRole;
    [SerializeField] private float _attackDamage;
    [SerializeField] private float _speed;

    public Faction Faction => _faction;
    public BattleRole BattleRole => _battleRole;
    public float AttackDamage => _attackDamage;
    public float Speed => _speed;
}
