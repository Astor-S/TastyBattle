using UnityEngine;

public class UnitMovementInput : MonoBehaviour
{
    [SerializeField] private UnitMovementProperties _properties;
    [SerializeField] private DetectionSystem _detectionSystem;
    [SerializeField] private Unit _enemyBase;

    private UnitMovementHandler _unitMovementHandler;
    private Unit _target;

    private void Awake() =>
        _unitMovementHandler = new UnitMovementHandler(_properties);

    private void Update()
    {
        if (_detectionSystem.DetectedUnits.Count > 0)
            _target = _detectionSystem.DetectedUnits[0];
        else
            _target = null;

        _unitMovementHandler.Move(GetTarget());
    }

    //private void OnEnable()
    //{
    //    _attacker.AttackStarted += OnAttackStarted;
    //    _attacker.AttackStopped += OnAttackStopped;
    //}

    //private void OnDisable()
    //{
    //    _attacker.AttackStarted -= OnAttackStarted;
    //    _attacker.AttackStopped -= OnAttackStopped;
    //}

    //private void OnAttackStarted()
    //{
    //    _target = _attacker.TargetAttack.transform.position;
    //}

    //private void OnAttackStopped()
    //{
    //    _target = _enemyBasePosition;
    //}

    private Vector3 GetTarget()
    {
        if (_target != null)
            return _target.transform.position;

        if (_enemyBase != null)
            return _enemyBase.transform.position;

        return _properties.UnitTransform.position;
    }
}
