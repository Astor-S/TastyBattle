using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using GameService.GameHandlerSystem;

namespace UI.Screens
{
    public class CompleteScreen : Window
    {
        [SerializeField] private Button _nextLevelButton;
        [SerializeField] private TMP_Text _victoryTimerView;  
        [SerializeField] private Timer _timer;

        public event Action ScreenActivated;

        private void OnEnable()
        {
            ScreenActivated?.Invoke();

            _victoryTimerView.text = " " + _timer.GetCurrentTime();
        }
    }
}