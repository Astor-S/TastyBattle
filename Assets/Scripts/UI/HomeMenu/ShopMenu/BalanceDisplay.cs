using UnityEngine;
using TMPro;
using YG;

namespace UI.HomeMenu.ShopMenu
{
    public class BalanceDisplay : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _balanceText;

        private void Start()
        {
            UpdateBalanceText();
        }

        private void UpdateBalanceText()
        {
            if (_balanceText != null && YG2.saves != null)
                _balanceText.text = YG2.saves.balanceMoney.ToString();
        }

        public void RefreshBalance()
        {
            //YG2.saves = YG2.savesData;
            UpdateBalanceText();
        }
    }
}