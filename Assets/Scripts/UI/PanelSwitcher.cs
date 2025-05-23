using System.Collections;
using UnityEngine;

public class PanelSwitcher : MonoBehaviour, ISwitchable
{
    private Transform _closingPanel;
    private WaitForSeconds _delay;
    private float _delayTime = 0.75f;

    private void OnEnable() =>
        _delay = new WaitForSeconds(_delayTime);

    public void Open(Transform openingPanel)
    {
        if (_closingPanel == null)
            _closingPanel = transform;

        _closingPanel.gameObject.SetActive(false);
        openingPanel.gameObject.SetActive(true);
    }

    public void OpenDelayed(Transform openingPanel) =>
        StartCoroutine(Delay(openingPanel));

    private IEnumerator Delay(Transform openingPanel)
    {
        if (_closingPanel == null)
            _closingPanel = transform;

        openingPanel.gameObject.SetActive(true);

        yield return _delay;

        _closingPanel.gameObject.SetActive(false);
        openingPanel.gameObject.SetActive(true);
    }
}
