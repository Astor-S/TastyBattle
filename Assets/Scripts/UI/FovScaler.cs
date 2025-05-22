using UnityEngine;

public class FovScaler : MonoBehaviour
{
    [SerializeField] private float _parameter1 = -10;
    [SerializeField] private float _parameter2 = 4;
    [SerializeField] private float _parameter3 = 100;

    private float _width;

    private void FixedUpdate()
    {
        _width = Camera.main.aspect * Camera.main.orthographicSize;

        Camera.main.fieldOfView = Mathf.Max(50f, _parameter1 * (_width - _parameter2) + _parameter3);
    }
}
