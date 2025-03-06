using UnityEngine;

public class UnitMovementProperties : MonoBehaviour
{
    [SerializeField] private Transform _unitTransform;

    public Transform UnitTransform => _unitTransform;
}
