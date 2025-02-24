using UnityEngine;

public class UnitMovementProperties : MonoBehaviour //можно заменить на ScriptableObject
{
    [SerializeField] private Transform _unitTransform;
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _approachDistance = 1.5f;

    public Transform UnitTransform => _unitTransform;
    public float Speed => _speed;
    public float ApproachDistance => _approachDistance;
}
