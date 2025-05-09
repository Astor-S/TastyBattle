using StructureElements;
using System;
using UnityEngine;
using AttackSystem;

public class BuildingPresenter : Presenter, IActivatable
{
    private const string Enemy = nameof(Enemy);
    private const string Player = nameof(Player);

    [SerializeField] private DamagableTarget _damagableTarget;

    private UpgradesData _upgradeData;

    private Action<DamagableTarget> _dyingDelegate;

    public new BuildingView View => base.View as BuildingView;
    public new Building Model => base.Model as Building;
    public DamagableSetup Stats => Model.Stats;
    public DamagableTarget DamagableTarget => _damagableTarget;
    public UpgradesData UpgradesData => _upgradeData;

    protected virtual void Awake()
    {
        _dyingDelegate = (_) => OnDying();

        if (gameObject.layer == LayerMask.NameToLayer(Player))
        {
            _upgradeData = Upgrades.Player;
            View.SetColor(Color.blue);
        }
        else if (gameObject.layer == LayerMask.NameToLayer(Enemy))
        {
            _upgradeData = Upgrades.Enemy;
            View.SetColor(Color.red);
        }
    }

    public virtual void Enable()
    {
        _damagableTarget.Init(Stats, _upgradeData);

        _damagableTarget.Dying += _dyingDelegate;
    }

    public virtual void Disable() => 
        _damagableTarget.Dying -= _dyingDelegate;

    protected virtual void OnDying() => 
        View.SetDeathAnimation();
}
