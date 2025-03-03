using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class OrderHandler : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private TextMeshProUGUI _priceTextBox;
    [SerializeField] private int _cost;

    private Order _order;

    public event Action<Order, int> ItemOrdered;

    private void Awake()
    {
        if (_priceTextBox != null)
            _priceTextBox.text = _cost.ToString();

        _order = InitializeOrder();
    }

    private void OnEnable()
    {
        if (_button != null)
            _button.onClick.AddListener(OrderUnit);
    }

    private void OnDisable()
    {
        if (_button != null)
            _button.onClick.RemoveListener(OrderUnit);
    }

    public void OrderUnit()
    {
        ItemOrdered?.Invoke(_order, _cost);
    }

    protected abstract Order InitializeOrder();
}
