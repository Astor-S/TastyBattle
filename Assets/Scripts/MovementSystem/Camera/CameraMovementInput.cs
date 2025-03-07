using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Camera))]
public class CameraMovementInput : MonoBehaviour
{
    public const string HorizontalAxisName = "Mouse X";
    public const string VerticalAxisName = "Mouse Y";

    [SerializeField] private CameraMovementProperties _properties;
    [SerializeField] private LayerMask _ground;
    [SerializeField] private float _outOfBoundsZone;

    private Camera _camera;
    private CameraMovementHandler _cameraMovementHandler;
    private bool _isDragged;

    private void Awake()
    {
        _camera = GetComponent<Camera>();
        _cameraMovementHandler = new CameraMovementHandler(_properties);
    }

    private void Update() =>
        _cameraMovementHandler.Move(Read());

    private Vector3 Read()
    {
        if (_camera.transform.position.x < -_outOfBoundsZone)
            return Vector3.right;
        if (_camera.transform.position.x > _outOfBoundsZone)
            return Vector3.left;

        if (Input.GetMouseButtonDown(0))
        {
            if (IsClickedOnGround())
                _isDragged = true;

            return Vector3.zero;
        }

        if (Input.GetMouseButtonUp(0))
        {
            _isDragged = false;
            return Vector3.zero;
        }

        if (_isDragged && Input.GetMouseButton(0))
            return new Vector3(-Input.GetAxis(HorizontalAxisName), 0, -Input.GetAxis(VerticalAxisName));

        return Vector3.zero;
    }

    private bool IsClickedOnGround()
    {
        Vector3 screenPositionPoint = Input.mousePosition;
        Ray ray = _camera.ScreenPointToRay(screenPositionPoint);

        bool result = Physics.Raycast(ray, out RaycastHit hit, float.MaxValue, _ground) &&
            EventSystem.current.IsPointerOverGameObject() == false;

        return result;
    }
}
