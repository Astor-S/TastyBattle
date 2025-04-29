using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using GameService;

namespace UI.Screens.ScreenButtons
{
    public class RestartLevelButton : MonoBehaviour
    {
        [SerializeField] private LevelLoader _levelLoader;

        public event Action GameContinued;

        public void OnButtonClick() 
        {
            string currentSceneName = SceneManager.GetActiveScene().name;
            StartCoroutine(_levelLoader.LoadLevelAsync(currentSceneName));
            GameContinued?.Invoke();
        }
    }
}