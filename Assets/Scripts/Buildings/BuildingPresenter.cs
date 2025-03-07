using StructureElements;
using UnityEngine;

public class BuildingPresenter : Presenter, IActivatable
{
    [SerializeField] protected DamagableTarget _damagableTarget;
    [SerializeField] private DamagableSetup _damagableSetup;

    public new BuildingView View => base.View as BuildingView;
    public DamagableSetup Stats => _damagableSetup;

    private void Start() =>
        SetColorSide();

    public virtual void Enable() =>
        _damagableTarget.Died += View.SetDeathAnimation;

    public virtual void Disable() =>
        _damagableTarget.Died -= View.SetDeathAnimation;

    private void SetColorSide()
    {
        if (gameObject.layer == LayerMask.NameToLayer("Player"))
            View.SetColor(Color.blue);
        else if (gameObject.layer == LayerMask.NameToLayer("Enemy"))
            View.SetColor(Color.red);
    }
}
