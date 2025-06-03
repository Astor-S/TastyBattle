using UnityEngine;

namespace MovementSystem.CameraMovement
{
    public class CameraMovementHandler
    {
        private readonly CameraMovementProperties _properties;
        private Vector3 _cameraDirection;

        public CameraMovementHandler(CameraMovementProperties properties)
        {
            _properties = properties;
            _cameraDirection = _properties.CameraTransform.position;
        }

        public void Move(Vector3 direction)
        {
            _cameraDirection += new Vector3(direction.x, 0, direction.y) * _properties.Speed;

            _cameraDirection.x = Mathf.Clamp(_cameraDirection.x, _properties.MinX, _properties.MaxX);

            _properties.CameraTransform.position = Vector3.Lerp(
                _properties.CameraTransform.position,
                _cameraDirection,
                Time.deltaTime / _properties.Smoothness);
        }
    }
}