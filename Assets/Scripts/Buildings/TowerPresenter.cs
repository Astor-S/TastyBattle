using UnityEngine;

public class TowerPresenter : BuildingPresenter
{
    [SerializeField] private RangedAttackSystem _attackSystem;

    public new AttackerSetup Stats => base.Stats as AttackerSetup;

    private void Awake()
    {
        _attackSystem.Init(Stats);
    }
}
