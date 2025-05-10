using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TutorialSkip : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler
{
    private const float FullAmount = 1f;

    [SerializeField] private Tutorial _tutorial;
    [SerializeField] private Image _skipPanel;
    [SerializeField] private float _speed = 1f;

    private Coroutine _coroutine;
    private WaitForFixedUpdate _charge;

    private void OnEnable() => 
        _charge = new WaitForFixedUpdate();

    public void OnPointerDown(PointerEventData eventData) => 
        _coroutine = StartCoroutine(Skip());

    public void OnPointerExit(PointerEventData eventData) => 
        StopCharging();


    public void OnPointerUp(PointerEventData eventData) => 
        StopCharging();

    private void StopCharging()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _skipPanel.fillAmount = 0;
    }

    private IEnumerator Skip()
    {
        while (_skipPanel.fillAmount < FullAmount)
        {
            yield return _charge;

            _skipPanel.fillAmount = Mathf.MoveTowards(_skipPanel.fillAmount, FullAmount, _speed * Time.deltaTime);
        }

        _tutorial.CloseTutorial();
    }
}
