using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using GameService.GameHandlerSystem;
using GameService.GameHandlerSystem.Counters;

namespace UI.Screens
{
    public abstract class Window : MonoBehaviour
    {
        [SerializeField] private Button _homeButton;
        [SerializeField] private Button _restartButton;
        [SerializeField] private Timer _timer;
        [SerializeField] private KilledEnemyCounter _killedEnemyCounter;
        [SerializeField] private TMP_Text _screenTimerView;
        [SerializeField] private TMP_Text _screenKilledView;
        [SerializeField] private Audio.AudioSettings _audioSettings;
        
        public event Action ScreenActivated;

        private void Awake() =>
            gameObject.SetActive(false);

        private void OnEnable()
        {
            _audioSettings.TurnOff();

            ScreenActivated?.Invoke();

            string spaceSymbol = " ";

            _screenTimerView.text = spaceSymbol + _timer.GetCurrentTime();
            _screenKilledView.text = spaceSymbol + _killedEnemyCounter.EnemiesKilled;
        }

        public void Open() =>
            gameObject.SetActive(true);
    }
}