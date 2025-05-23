using UnityEngine;

public class IntroMaker : MonoBehaviour
{
    [SerializeField] private Transform _camera;
    [SerializeField] private Transform _point;
    [SerializeField] private float _speed;

    private void Update()
    {
        _camera.position = Vector3.MoveTowards(_camera.position, _point.position, _speed * Time.deltaTime);
    }
}
