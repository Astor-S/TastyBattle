using UnityEngine;

public class UnitMovementInput : MonoBehaviour
{
    [SerializeField] private UnitSetup _stats;
    [SerializeField] private UnitMovementProperties _properties;
    [SerializeField] private DetectionSystem _detectionSystem;

    private DamagableTarget _enemyBase;
    private UnitMovementHandler _unitMovementHandler;
    private DamagableTarget _target;

    private void Start() => 
        _unitMovementHandler = new UnitMovementHandler(_stats, _properties);

    private void Update()
    {
        SetTarget();

        _unitMovementHandler.Move(GetTarget());
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

        return _properties.UnitTransform.position;
    }

    public void SetEnemyBase(DamagableTarget damagableTarget)
    {
        if (_enemyBase == null)
            _enemyBase = damagableTarget;
    }
}
