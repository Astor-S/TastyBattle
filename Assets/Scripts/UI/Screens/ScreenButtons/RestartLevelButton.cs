using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using GameService;
using GameService.GameHandlerSystem.Handlers;

namespace UI.Screens.ScreenButtons
{
    public class RestartLevelButton : MonoBehaviour
    {
        [SerializeField] private LevelLoader _levelLoader;
        [SerializeField] private PauseHandler _pauseHandler;
        
        public event Action GameContinued;

        public void OnButtonClick() 
        {
            _pauseHandler.ContinueGame();
            string currentSceneName = SceneManager.GetActiveScene().name;
            StartCoroutine(_levelLoader.LoadLevelAsync(currentSceneName));
            GameContinued?.Invoke();
        }
    }
}