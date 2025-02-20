using UnityEngine;
using UnityEngine.UI;

public class HealthBarView : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private RectTransform _targetCanvas;
    [SerializeField] private Transform _followedObject;

    private void LateUpdate()
    {
        transform.LookAt(transform.position + Camera.main.transform.rotation * Vector3.forward,
                         Camera.main.transform.rotation * Vector3.up);
    }

    public void UpdateHealth(float health, float maxHealth)
    {
        if (health == 0)
        {
            _slider.fillRect.gameObject.SetActive(false);
        }
        else
        {
            _slider.value = health / maxHealth;
            _slider.fillRect.gameObject.SetActive(true);
        }
    }
}