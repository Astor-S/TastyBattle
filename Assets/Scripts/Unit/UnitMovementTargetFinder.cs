using UnityEngine;

public class UnitMovementTargetFinder : MonoBehaviour
{
    [SerializeField] private UnitMovementProperties _properties;
    [SerializeField] private Transform _target;

    private UnitMovementHandler _unitMovementHandler;

    private void Awake() => 
        _unitMovementHandler = new UnitMovementHandler(_properties);

    private void Update() => 
        _unitMovementHandler.Move(GetTarget());

    private Vector3 GetTarget()
    {
        if (_target != null)
            return _target.position;

        return _properties.UnitTransform.position;
    }
}
