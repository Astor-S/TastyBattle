using UnityEngine;
using UnityEngine.UI;
using GameService;
using System;
using System.Collections.Generic;

namespace UI.HomeMenu.CampaignMenu
{
    public class LevelButton : MonoBehaviour
    {
        [SerializeField] private List<LevelCell> _levelCells;
        [SerializeField] private Button _button;
        [SerializeField] private UnitMapView _unitMapView;

        private int _currentLevelIndex;

        public event Action<LevelButton> Selected;

        public UnitMapView UnitMapView => _unitMapView;
        public IReadOnlyList<LevelCell> LevelCells => _levelCells;

        private void Awake() => 
            _button.onClick.AddListener(Select);        

        private void Start() => 
            UpdateLevelButton();

        public void SetCurrentLevelIndex(int index)
        {
            _currentLevelIndex = index;
        }

        public void UpdateLevelButton()
        {
            if (_levelCells == null || _levelCells.Count == 0)
            {
                _button.interactable = false;
                return;
            }

            if (_currentLevelIndex < 0 || _currentLevelIndex >= _levelCells.Count)
            {
                _button.interactable = false;
                return;
            }

            Levels levelToCheck = _levelCells[_currentLevelIndex].LevelsType;
            //bool isLevelOpened = _savesYG.IsLevelOpen(levelToCheck);
            //_button.interactable = isLevelOpened;
        }        

        private void Select() => 
            Selected?.Invoke(this);
    }
}