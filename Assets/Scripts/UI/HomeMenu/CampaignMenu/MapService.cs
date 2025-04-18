using UnityEngine;

namespace UI.HomeMenu.CampaignMenu
{
    public class MapService : MonoBehaviour
    {
        private const int FirstCampaign = 0;
        private const int CorrectionShift = 1;

        [SerializeField] private UnitMapView[] _levelDataByCampaign;
        [SerializeField] private LevelButton[] _levelButtons;
        [SerializeField] private MapDisplay _mapDisplay;
        [SerializeField] private Transform _playerContainer;
        [SerializeField] private Transform _enemyContainer;

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
            _mapDisplay.DisplayMap(_levelDataByCampaign[button.ButtonIndex], _enemyContainer, _mapDisplay.EnemyDescriptionField);

            _selectedButton = button;
        }

        public void LoadCurrentLevel()
        {
            if (_selectedButton.LevelCells == null || _selectedButton.LevelCells.Count == 0)
                return;

            if (_currentCampaignIndex < 0 || _currentCampaignIndex >= _selectedButton.LevelCells.Count)
                return;

            _selectedButton.LevelCells[_currentCampaignIndex].LoadScene();
        }

        public void ChangeCampaign(int change)
        {
            _currentCampaignIndex += change;

            if (_currentCampaignIndex < FirstCampaign)
                _currentCampaignIndex = _levelDataByCampaign.Length - CorrectionShift;
            else if (_currentCampaignIndex > _levelDataByCampaign.Length - CorrectionShift)
                _currentCampaignIndex = FirstCampaign;

            if (_mapDisplay != null)
                _mapDisplay.DisplayMap(_levelDataByCampaign[_currentCampaignIndex], _playerContainer, _mapDisplay.PlayerDescritionField);

            _selectedButton = null;

            UpdateLevelButtons();
        }

        private void UpdateLevelButtons()
        {
            for (int i = 0; i < _levelButtons.Length; i++)
            {
                int buttonIndex = i;
                _levelButtons[buttonIndex].SetCurrentLevelIndex(_currentCampaignIndex);
                _levelButtons[buttonIndex].UpdateLevelButton();
            }
        }
    }
}