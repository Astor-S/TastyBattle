using System;
using UnityEngine;
using NaughtyAttributes;
using GameService;
using YG;
using GameService.GameHandlerSystem.Handlers;

namespace UI.Screens.ScreenButtons
{
    public class LoadSceneButton : MonoBehaviour
    {
        [Scene]
        [SerializeField] private string _sceneToLoad;
        [SerializeField] private LevelLoader _levelLoader;
        [SerializeField] private PauseHandler _pauseHandler;

        public event Action GameContinued;

        public void OnButtonClick()
        {
            YG2.InterstitialAdvShow();
            _pauseHandler.ContinueGame();
            StartCoroutine(_levelLoader.LoadLevelAsync(_sceneToLoad));
            GameContinued?.Invoke();
        }
    }
}