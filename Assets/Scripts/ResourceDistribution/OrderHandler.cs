using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public abstract class OrderHandler : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private TextMeshProUGUI _priceTextBox;
    [SerializeField] private Image _icon;
    [SerializeField] private int _initialCost;

    private Order _order;

    public event Action<Order> ItemOrdered;

    public TextMeshProUGUI PriceTextBox => _priceTextBox;
    public int CurrentCost => _order.Cost;
    protected Order Order => _order;

    private void Awake()
    {
        _order = InitializeOrder(_initialCost);

        if (_priceTextBox != null)
            _priceTextBox.text = _initialCost.ToString();
    }

    private void OnEnable()
    {
        if (_button != null)
            _button.onClick.AddListener(MakeOrder);
    }

    private void OnDisable()
    {
        if (_button != null)
            _button.onClick.RemoveListener(MakeOrder);
    }

    public void SetUnavailable()
    {
        if (_button != null)
            _button.interactable = false;

        if (_icon != null)
            _icon.color = Color.gray;
    }

    public void SetAvailable()
    {
        if (_order.IsAvailable)
        {
            if (_button != null)
                _button.interactable = true;

            if (_icon != null)
                _icon.color = Color.white;
        }
    }

    public void MakeOrder()
    {
        try
        {
            if (_order.IsAvailable)
            {
                ItemOrdered?.Invoke(_order);
                OnOrdered();

                if (_priceTextBox != null)
                    _priceTextBox.text = _order.Cost.ToString();

                if (_order.IsAvailable == false)
                {
                    _priceTextBox.gameObject.SetActive(false);
                    _button.interactable = false;
                }
            }
        }
        catch (InvalidOperationException exc)
        {
            Debug.Log(exc.Message);
        }
    }

    protected abstract Order InitializeOrder(int initialCost);

    protected abstract void OnOrdered();
}
