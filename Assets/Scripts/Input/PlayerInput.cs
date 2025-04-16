using UnityEngine;
using UnityEngine.UI;

public class PlayerInput : MonoBehaviour
{
    private const string Player = nameof(Player);

    [SerializeField] private Camera _camera;
    [SerializeField] private ScrollRect _unitMenu;

    private bool _isUnitMenuOpen = false;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit, float.MaxValue, LayerMask.GetMask(Player)) &&
                hit.transform.TryGetComponent(out MainBuildingView @base))
            {
                if (_isUnitMenuOpen)
                    _unitMenu.gameObject.SetActive(false);
                else
                    _unitMenu.gameObject.SetActive(true);

                @base.ToggleSelection();
                _isUnitMenuOpen = !_isUnitMenuOpen;
            }
        }
    }
}
