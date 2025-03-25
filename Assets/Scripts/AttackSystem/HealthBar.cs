using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private DamagableTarget _damagableTarget;
    [SerializeField] private HealthBarView _view;

    private void Awake()
    {
        _damagableTarget.Inited += () => enabled = true;
        enabled = false;
    }

    private void OnEnable()
    {
        if (_damagableTarget.Health != null)
            _damagableTarget.Health.ValueChanged += _view.UpdateVisualHealth;
    }

    private void OnDisable()
    {
        if (_damagableTarget.Health != null)
            _damagableTarget.Health.ValueChanged -= _view.UpdateVisualHealth;
    }
}