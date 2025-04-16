using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Screens
{
    public class CompleteScreen : Window
    {
        [SerializeField] private Button _nextLevelButton;

        public event Action ScreenActivated;

        private void OnEnable()
        {
            ScreenActivated?.Invoke();
        }
    }
}