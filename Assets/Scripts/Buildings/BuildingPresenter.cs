using StructureElements;
using System;
using UnityEngine;
using AttackSystem;

public class BuildingPresenter : Presenter, IActivatable, IUpgradable
{
    [SerializeField] private DamagableTarget _damagableTarget;

    private Action<DamagableTarget> _dyingDelegate;

    public new BuildingView View => base.View as BuildingView;
    public new Building Model => base.Model as Building;
    public DamagableSetup Stats => Model.Stats;
    public UpgradeHandler UpgradeHandler => Model.UpgradeHandler;
    public DamagableTarget DamagableTarget => _damagableTarget;

    protected virtual void Awake()
    {
        _dyingDelegate = (_) => OnDying();

        if (gameObject.layer == LayerMask.NameToLayer("Player"))
            View.SetColor(Color.blue);
        else if (gameObject.layer == LayerMask.NameToLayer("Enemy"))
            View.SetColor(Color.red);
    }

    public virtual void Enable()
    {
        _damagableTarget.Init(Stats, UpgradeHandler);

        _damagableTarget.Dying += _dyingDelegate;
    }

    public virtual void Disable() => 
        _damagableTarget.Dying -= _dyingDelegate;

    protected virtual void OnDying() => 
        View.SetDeathAnimation();
}
