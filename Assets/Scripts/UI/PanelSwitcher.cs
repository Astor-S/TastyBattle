using UnityEngine;

public class PanelSwitcher : MonoBehaviour, ISwitchable
{
    private Transform _closingPanel;

    public void Open(Transform openingPanel)
    {
        if (_closingPanel == null)
            _closingPanel = transform;

        _closingPanel.gameObject.SetActive(false);
        openingPanel.gameObject.SetActive(true);
    }
}
