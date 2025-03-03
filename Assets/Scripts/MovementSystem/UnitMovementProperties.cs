using UnityEngine;

public class UnitMovementProperties : MonoBehaviour //можно заменить на ScriptableObject
{
    [SerializeField] private Transform _unitTransform;
    [SerializeField] private UnitStats _unitStats;

    public Transform UnitTransform => _unitTransform;
}
