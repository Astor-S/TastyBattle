using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private DamagableTarget _damagableTarget;
    [SerializeField] private HealthBarView _view;

    private void OnEnable()
    {
        _damagableTarget.Health.ValueChanged += _view.UpdateVisualHealth;
    }

    private void OnDisable()
    {
        _damagableTarget.Health.ValueChanged -= _view.UpdateVisualHealth;
    }
}