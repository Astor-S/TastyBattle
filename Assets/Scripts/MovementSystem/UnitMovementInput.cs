using UnityEngine;

public class UnitMovementInput : MonoBehaviour
{
    [SerializeField] private UnitSetup _stats;
    [SerializeField] private UnitMovementProperties _properties;
    [SerializeField] private DetectionSystem _detectionSystem;

    private Transform _initialTarget;
    private DamagableTarget _currentTarget;
    private UnitMovementHandler _unitMovementHandler;

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
            _currentTarget = _detectionSystem.DetectedUnits[0];
        else
            _currentTarget = null;
    }

    private Vector3 GetTarget()
    {
        if (_currentTarget != null)
            return _currentTarget.transform.position;

        if (_initialTarget != null)
            return _initialTarget.position;

        return _properties.UnitTransform.position;
    }

    public void SetInitialTarget(Transform initialTarget)
    {
        if (_initialTarget == null)
            _initialTarget = initialTarget;
    }
}
