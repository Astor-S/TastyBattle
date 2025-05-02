using UnityEngine;
using TMPro;

namespace GameService.GameHandlerSystem.Counters
{
    public class CoinCounter : MonoBehaviour
    {
        private readonly string _sympolPlus = "+";

        [SerializeField] private TextMeshProUGUI _coinText;
        [SerializeField] private LevelRewarder _levelRewarder;

        private void OnEnable()
        {
            UpdateCoinText();
        }

        private void OnDisable()
        {
            UpdateCoinText();
        }

        private void UpdateCoinText() =>
            _coinText.text = _sympolPlus + _levelRewarder.TotalCoins.ToString();
    }
}