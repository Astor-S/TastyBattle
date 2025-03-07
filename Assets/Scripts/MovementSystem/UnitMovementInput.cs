using UnityEngine;

public class UnitMovementInput : MonoBehaviour
{
    [SerializeField] private DetectionSystem _detectionSystem;
    [SerializeField] private Transform _unitTransform;

    private Transform _initialTarget;
    private DamagableTarget _currentTarget;
    private UnitMovementHandler _unitMovementHandler;

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

        return transform.position;
    }

    public void SetInitialTarget(Transform initialTarget)
    {
        if (_initialTarget == null)
            _initialTarget = initialTarget;
    }
}
