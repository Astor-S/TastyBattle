using UnityEngine;

public class UnitMovementProperties : MonoBehaviour
{
    [SerializeField] private Transform _unitTransform;
    [SerializeField] private UnitSetup _unitStats;

    public Transform UnitTransform => _unitTransform;
}
