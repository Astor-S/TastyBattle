using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI.HomeMenu.CampaignMenu
{
    public class LevelButton : MonoBehaviour
    {
        [SerializeField] private LevelCell[] _levelCells;
        [SerializeField] private Button _button;

        private int _currentLevelIndex;

        private void Awake()
        {
            _button.onClick.AddListener(LoadCurrentLevel);
        }

        private void Start()
        {
            UpdateLevelButton();
        }

        public void SetCurrentLevelIndex(int index)
        {
            _currentLevelIndex = index;
            UpdateLevelButton();
        }

        public void UpdateLevelButton()
        {
            throw new NotImplementedException();
        }

        private void LoadCurrentLevel()
        {
            if (_levelCells == null || _levelCells.Length == 0)
                return;

            if (_currentLevelIndex < 0 || _currentLevelIndex >= _levelCells.Length)
                return;

            _levelCells[_currentLevelIndex].LoadScene();
        }
    }
}