using UnityEngine;

namespace UI.HomeMenu.CampaignMenu
{
    public class MapService : MonoBehaviour
    {
        private const int FirstCampaign = 0;
        private const int CorrectionShift = 1;

        [SerializeField] private Map[] _levelDataByCampaign;
        [SerializeField] private LevelButton[] _levelButtons;
        [SerializeField] private MapDisplay _mapDisplay;

        private int _currentCampaignIndex;

        private void Awake()
        {
            ChangeCampaign(FirstCampaign);
        }

        public void ChangeCampaign(int change)
        {
            _currentCampaignIndex += change;

            if (_currentCampaignIndex < FirstCampaign)
                _currentCampaignIndex = _levelDataByCampaign.Length - CorrectionShift;
            else if (_currentCampaignIndex > _levelDataByCampaign.Length - CorrectionShift)
                _currentCampaignIndex = FirstCampaign;

            if (_mapDisplay != null)
                _mapDisplay.DisplayMap(_levelDataByCampaign[_currentCampaignIndex]);

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