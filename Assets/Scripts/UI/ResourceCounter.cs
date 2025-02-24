using ResourceDistribution;
using TMPro;
using UnityEngine;

public class ResourceCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _counterTextBox;

    private Wallet _wallet;

    public void Init(Wallet wallet)
    {
        _wallet = wallet;

        ChangeAmountView();

        _wallet.ResourceRecieved += ChangeAmountView;
        _wallet.ResourceSpend += ChangeAmountView;
    }

    private void OnEnable()
    {
        if (_wallet != null)
        {
            _wallet.ResourceRecieved += ChangeAmountView;
            _wallet.ResourceSpend += ChangeAmountView;
        }
    }

    private void OnDisable()
    {
        if (_wallet != null)
        {
            _wallet.ResourceRecieved -= ChangeAmountView;
            _wallet.ResourceSpend -= ChangeAmountView;
        }
    }

    private void ChangeAmountView()
    {
        _counterTextBox.text = _wallet.ResourceCount.ToString();
    }
}
