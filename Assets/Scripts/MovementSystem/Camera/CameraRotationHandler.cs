using DG.Tweening;
using UnityEngine;

public class CameraRotationHandler : MonoBehaviour
{
    [SerializeField] private Transform _initialTarget;
    [SerializeField] private float _rotateDuration;

    private void Awake() => 
        LookAt(_initialTarget);

    public void LookAt(Transform target) =>
        transform.DOLookAt(target.position, _rotateDuration);
}
