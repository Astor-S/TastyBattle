using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class OrderHandler : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private TextMeshProUGUI _priceTextBox;
    [SerializeField] private int _initialCost;

    private Order _order;

    public event Action<Order> ItemOrdered;

    protected int InitialCost => _initialCost;

    private void Awake()
    {
        _order = InitializeOrder(_initialCost);

        if (_priceTextBox != null)
            _priceTextBox.text = _initialCost.ToString();
    }

    private void OnEnable()
    {
        if (_button != null)
            _button.onClick.AddListener(Order);
    }

    private void OnDisable()
    {
        if (_button != null)
            _button.onClick.RemoveListener(Order);
    }

    public void Order()
    {
        try
        {
            ItemOrdered?.Invoke(_order);
            _order.IncreaseCost();

            if (_priceTextBox != null)
                _priceTextBox.text = _order.Cost.ToString();
        }
        catch (InvalidOperationException exc)
        {
            Debug.Log(exc.Message);
        }
    }

    protected abstract Order InitializeOrder(int initialCost);
}
