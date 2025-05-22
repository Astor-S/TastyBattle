using UnityEngine;

public class FovScaler : MonoBehaviour
{
    [SerializeField] private float _parameter;

    private void FixedUpdate()
    {
        float width = Camera.main.aspect * Camera.main.orthographicSize;

        if (width <= _parameter)
            Camera.main.fieldOfView = _parameter / width * 50.0f;
    }
}
