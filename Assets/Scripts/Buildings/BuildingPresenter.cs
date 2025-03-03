using StructureElements;
using UnityEngine;

public class BuildingPresenter : Presenter
{
    [SerializeField] protected DamagableTarget _damagableTarget;
    [SerializeField] protected BuildingView _buildingView;

    private void Start() =>
        SetColorSide();

    private void SetColorSide()
    {
        if (gameObject.layer == LayerMask.NameToLayer("Player"))
            _buildingView.SetColor(Color.blue);
        else if (gameObject.layer == LayerMask.NameToLayer("Enemy"))
            _buildingView.SetColor(Color.red);
    }

    public virtual void OnEnable() => 
        _damagableTarget.Died += _buildingView.SetDeathAnimation;

    public virtual void OnDisable() => 
        _damagableTarget.Died -= _buildingView.SetDeathAnimation;
}
