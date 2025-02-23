using UnityEngine;

public class UnitMovementTargetFinder : MonoBehaviour
{
    [SerializeField] private UnitMovementProperties _properties;

    private Attacker _attacker;
    private Vector3 _target;
    private Vector3 _enemyBasePosition;
    private UnitMovementHandler _unitMovementHandler;

    private void Awake()
    {
        _unitMovementHandler = new UnitMovementHandler(_properties);
        
        if (TryGetComponent(out Attacker attacker))
            _attacker = attacker;
    }

    private void Start()
    {
        _enemyBasePosition = new Vector3(-transform.position.x, transform.position.y, transform.position.z);
        _target = _enemyBasePosition;
    }

    private void Update() => 
        _unitMovementHandler.Move(GetTarget());

    private void OnEnable()
    {
        _attacker.AttackStarted += OnAttackStarted;
        _attacker.AttackStopped += OnAttackStopped;
    }

    private void OnDisable()
    {
        _attacker.AttackStarted -= OnAttackStarted;
        _attacker.AttackStopped -= OnAttackStopped;
    }

    private void OnAttackStarted()
    {
        _target = _attacker.Target;
    }

    private void OnAttackStopped()
    {
        _target = _enemyBasePosition;
    }

    private Vector3 GetTarget()
    {
        if (_target != null)
            return _target;

        return _properties.UnitTransform.position;
    }
}
