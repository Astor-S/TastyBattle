using UnityEngine;

public class PanelSwitcher : MonoBehaviour, ISwitchable
{
    [SerializeField] private Transform _closingPanel;

    public void Open(Transform openingPanel)
    {
        _closingPanel.gameObject.SetActive(false);
        openingPanel.gameObject.SetActive(true);
    }
}
