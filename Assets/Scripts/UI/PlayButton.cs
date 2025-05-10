using System.Collections;
using System.Collections.Generic;
using UI.HomeMenu.CampaignMenu;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class PlayButton : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private PanelSwitcher _panelSwitcher;
    [SerializeField] private MapService _mapService;
    [SerializeField] private CameraRotationHandler _cameraRotationHandler;
    [SerializeField] private Transform _levelsPanel;
    [SerializeField] private Transform _rightCanvas;

    private void OnEnable()
    {
        if (YG2.saves.IsFirstLaunch == false)
            _button.onClick.AddListener(StartTutorial);
        else
            _button.onClick.AddListener(OpenLevelsPanel);
    }

    private void OnDisable()
    {
        if (YG2.saves.IsFirstLaunch == false)
            _button.onClick.RemoveListener(StartTutorial);
        else
            _button.onClick.RemoveListener(OpenLevelsPanel);
    }

    public void StartTutorial()
    {
        //YG2.saves.IsFirstLaunch = true;
        //YG2.SaveProgress();

        _mapService.StartTutorial();
    }

    public void OpenLevelsPanel()
    {
        _panelSwitcher.Open(_levelsPanel);
        _cameraRotationHandler.LookAt(_rightCanvas);
    }
}
