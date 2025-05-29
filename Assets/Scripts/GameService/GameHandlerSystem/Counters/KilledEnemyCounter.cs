using UnityEngine;
using TMPro;

namespace GameService.GameHandlerSystem.Counters
{
    public class KilledEnemyCounter : MonoBehaviour
    {
        private readonly string _sympolSpace = " ";

        [SerializeField] private TextMeshProUGUI _killCountText;
        
        private int _enemiesKilled = 0;

        public int EnemiesKilled => _enemiesKilled;

        public void EnemyKilled()
        {
            _enemiesKilled++;
            UpdateKillCountUI(); 
        }

        private void UpdateKillCountUI()
        {
            if (_killCountText != null)
                _killCountText.text = _sympolSpace + _enemiesKilled.ToString();
        }
    }
}