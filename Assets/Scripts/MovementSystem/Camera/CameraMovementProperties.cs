using UnityEngine;

public class CameraMovementProperties : MonoBehaviour
{
    [SerializeField] private Transform _cameraTransform;
    [SerializeField] private float _speed = 1f;
    [SerializeField] private float _smoothness = 0.2f;
    [SerializeField] private float _minX = 0f;
    [SerializeField] private float _maxX = 1f;

    public Transform CameraTransform => _cameraTransform;
    public float Speed => _speed;
    public float Smoothness => _smoothness;

    public float MinX => _minX; 
    public float MaxX => _maxX;  
}