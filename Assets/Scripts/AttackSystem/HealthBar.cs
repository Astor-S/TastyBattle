using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private DamagableTarget _damagableTarget;
    [SerializeField] private HealthBarView _view;

    private bool _inited = false;

    private void OnEnable()
    {
        if (_inited)
            _damagableTarget.Health.ValueChanged += _view.UpdateVisualHealth;
        else
            _damagableTarget.Inited += OnDamagableTargetInited;
    }

    private void OnDisable()
    {
        if (_inited)
            _damagableTarget.Health.ValueChanged -= _view.UpdateVisualHealth;
        else
            _damagableTarget.Inited -= OnDamagableTargetInited;
    }

    private void OnDamagableTargetInited()
    {
        _inited = true;
        _damagableTarget.Health.ValueChanged += _view.UpdateVisualHealth;
    }
}