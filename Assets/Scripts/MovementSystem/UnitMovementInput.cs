using UnityEngine;

public class UnitMovementInput : MonoBehaviour
{
    [SerializeField] private DetectionSystem _detectionSystem;
    [SerializeField] private Transform _unitTransform;

    private DamagableTarget _enemyBase;
    private UnitMovementHandler _unitMovementHandler;
    private DamagableTarget _target;

    private void Update()
    {
        SetTarget();

        _unitMovementHandler.Move(GetTarget());
    }

    public void Init(UnitSetup unitSetup)
    {
        _unitMovementHandler = new UnitMovementHandler(unitSetup, _unitTransform);
    }

    private void SetTarget()
    {
        if (_detectionSystem.DetectedUnits.Count > 0)
            _target = _detectionSystem.DetectedUnits[0];
        else
            _target = null;
    }

    private Vector3 GetTarget()
    {
        if (_target != null)
            return _target.transform.position;

        if (_enemyBase != null)
            return _enemyBase.transform.position;

        return transform.position;
    }

    public void SetEnemyBase(DamagableTarget damagableTarget)
    {
        if (_enemyBase == null)
            _enemyBase = damagableTarget;
    }
}
