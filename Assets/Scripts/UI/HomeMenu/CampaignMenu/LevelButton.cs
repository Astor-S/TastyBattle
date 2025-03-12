using UnityEngine;
using UnityEngine.UI;
using GameService;

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
            if (_levelCells == null || _levelCells.Length == 0)
            {
                _button.interactable = false;
                return;
            }

            if (_currentLevelIndex < 0 || _currentLevelIndex >= _levelCells.Length)
            {
                _button.interactable = false;
                return;
            }

            Levels levelToCheck = _levelCells[_currentLevelIndex].LevelsType;
            //bool isLevelOpened = _savesYG.IsLevelOpen(levelToCheck);
            //_button.interactable = isLevelOpened;
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