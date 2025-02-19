using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Slider _slider;
    [SerializeField] private RectTransform _targetCanvas;
    [SerializeField] private Transform _followedObject;

    private void OnEnable()
    {
        _health.ValueChanged += UpdateHealth;
    }

    private void OnDisable()
    {
        _health.ValueChanged -= UpdateHealth;
    }

    private void UpdateHealth(float health, float maxHealth)
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