using UnityEngine;
using Units;

[CreateAssetMenu(fileName="Unit", menuName="Unit", order=51)]
public class UnitStats : ScriptableObject
{
    [SerializeField] private Faction _faction;
    [SerializeField] private BattleRole _battleRole;
    [SerializeField] private float _attackDamage;
    [SerializeField] private float _attackFrequency;
    [SerializeField] private float _speed;
    [SerializeField] private float _approachDistance;

    public Faction Faction => _faction;
    public BattleRole BattleRole => _battleRole;
    public float AttackDamage => _attackDamage;
    public float AttackFrequency => _attackFrequency;
    public float Speed => _speed;
    public float ApproachDistance => _approachDistance;
}
