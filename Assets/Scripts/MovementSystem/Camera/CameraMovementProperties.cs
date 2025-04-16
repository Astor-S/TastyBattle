using UnityEngine;

public class CameraMovementProperties : MonoBehaviour
{
    [SerializeField] private Transform _cameraTransform;
    [SerializeField] private float _speed = 1f;
    [SerializeField] private float _smoothness = 0.2f;

    public Transform CameraTransform => _cameraTransform;
    public float Speed => _speed;
    public float Smoothness => _smoothness;
}
