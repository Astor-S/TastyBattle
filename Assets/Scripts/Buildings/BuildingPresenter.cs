using StructureElements;
using UnityEngine;

public class BuildingPresenter : Presenter
{
    [SerializeField] private DamagableTarget _damagableTarget;
    [SerializeField] private BuildingView _view;

    private void Start() =>
        SetColorSide();

    private void SetColorSide()
    {
        if (gameObject.layer == LayerMask.NameToLayer("Player"))
            _view.SetColor(Color.blue);
        else if (gameObject.layer == LayerMask.NameToLayer("Enemy"))
            _view.SetColor(Color.red);
    }

    public void OnEnable() => 
        _damagableTarget.Died += _view.SetDeathAnimation;

    public void OnDisable() => 
        _damagableTarget.Died -= _view.SetDeathAnimation;
}
