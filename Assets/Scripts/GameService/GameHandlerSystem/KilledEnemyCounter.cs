using UnityEngine;
using TMPro;

namespace GameService.GameHandlerSystem
{
    public class KilledEnemyCounter : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _killCountText;
        
        private int _enemiesKilled = 0;

        public int EnemiesKilled => _enemiesKilled;

        public void EnemyKilled()
        {
            _enemiesKilled++;
            Debug.Log(" " + _enemiesKilled);
            UpdateKillCountUI(); 
        }

        private void UpdateKillCountUI()
        {
            if (_killCountText != null)
                _killCountText.text = " " + _enemiesKilled.ToString();
        }
    }
}