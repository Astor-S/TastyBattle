using StructureElements;
using UnityEngine;

public class MainBuildingView : View
{
    [SerializeField] private Outline _outline;

    private bool _isSelected = false;

    public void ToggleSelection()
    {
        if (_outline == null)
            return;

        _isSelected = !_isSelected;
        _outline.enabled = _isSelected;
    }
}
