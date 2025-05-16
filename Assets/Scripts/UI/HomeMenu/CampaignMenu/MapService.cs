using DG.Tweening;
using GameService;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using YG;

namespace UI.HomeMenu.CampaignMenu
{
    public class MapService : MonoBehaviour
    {
        private const int FirstCampaign = 0;
        private const int CorrectionShift = 1;
        [SerializeField] private UnitModelView[] _levelDataByCampaign;
        [SerializeField] private LevelButton[] _levelButtons;
        [SerializeField] private Button _watchAdButton;
        [SerializeField] private MapDisplay _mapDisplay;
        [SerializeField] private Transform _playerContainer;
        [SerializeField] private Transform _enemyContainer;

        private int _iceCreamCampaignIndex = 4;
        private int _currentCampaignIndex;
        private LevelButton _selectedButton;

        private void Awake() =>
            ChangeCampaign(FirstCampaign);

        private void OnEnable()
        {
            foreach (LevelButton levelButton in _levelButtons)
                levelButton.Selected += MarkSelected;
        }

        private void OnDisable()
        {
            foreach (LevelButton levelButton in _levelButtons)
                levelButton.Selected -= MarkSelected;
        }

        private void MarkSelected(LevelButton button)
        {
            _selectedButton = button;

            _mapDisplay.DisplayMap(_levelDataByCampaign[(int)_selectedButton.LevelCells[_currentCampaignIndex].EnemyFaction], _enemyContainer, _mapDisplay.EnemyDescriptionField);
        }

        public void LoadCurrentLevel()
        {
            if (_selectedButton == null)
                return;

            if (_selectedButton.LevelCells == null || _selectedButton.LevelCells.Count == 0)
                return;

            if (_currentCampaignIndex < 0 || _currentCampaignIndex >= _selectedButton.LevelCells.Count)
                return;

            _selectedButton.LevelCells[_currentCampaignIndex].LoadScene();
        }

        public void ChangeCampaign(int change)
        {
            _currentCampaignIndex += change;

            if (_currentCampaignIndex == _iceCreamCampaignIndex && YG2.saves.openedLevels.Contains(Levels.Level21) == false)
                _watchAdButton.gameObject.SetActive(true);           

            if (_currentCampaignIndex < FirstCampaign)
                _currentCampaignIndex = _levelDataByCampaign.Length - CorrectionShift;
            else if (_currentCampaignIndex > _levelDataByCampaign.Length - CorrectionShift)
                _currentCampaignIndex = FirstCampaign;

            if (_mapDisplay != null)
                _mapDisplay.DisplayMap(_levelDataByCampaign[_currentCampaignIndex], _playerContainer, _mapDisplay.PlayerDescriptionField);

            _selectedButton = null;

            UpdateLevelButtons();
        }

        public void UpdateLevelButtons()
        {
            for (int i = 0; i < _levelButtons.Length; i++)
            {
                int buttonIndex = i;
                _levelButtons[buttonIndex].SetCurrentLevelIndex(_currentCampaignIndex);
                _levelButtons[buttonIndex].UpdateLevelButton();
            }
        }

        //TODO
        public void StartTutorial()
        {
            if (YG2.saves.isFirstLaunch)
            {                      
                YG2.saves.isFirstLaunch = false;
                YG2.SaveProgress();

                DOTween.Clear();

                SceneManager.LoadScene("Tutorial");
            }
        }
    }
}