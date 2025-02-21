using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private HealthBarView _view;

    private void OnEnable()
    {
        _health.ValueChanged += _view.UpdateVisualHealth;
    }

    private void OnDisable()
    {
        _health.ValueChanged -= _view.UpdateVisualHealth;
    }
}