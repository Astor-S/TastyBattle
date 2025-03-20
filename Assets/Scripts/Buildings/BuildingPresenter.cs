using StructureElements;
using UnityEngine;

public class BuildingPresenter : Presenter, IActivatable
{
    [SerializeField] private DamagableTarget _damagableTarget;
    
    private DamagableSetup _damagableSetup;

    public new BuildingView View => base.View as BuildingView;
    public DamagableSetup Stats => _damagableSetup;
    public DamagableTarget DamagableTarget => _damagableTarget;

    private void Start()
    {
        SetColorSide();
    }

    public virtual void Enable()
    {
        _damagableTarget.Init(_damagableSetup);

        _damagableTarget.Dying += View.SetDeathAnimation;
    }

    public virtual void Disable()
    {
        _damagableTarget.Dying -= View.SetDeathAnimation;
    }

    private void SetColorSide()
    {
        if (gameObject.layer == LayerMask.NameToLayer("Player"))
            View.SetColor(Color.blue);
        else if (gameObject.layer == LayerMask.NameToLayer("Enemy"))
            View.SetColor(Color.red);
    }
}
