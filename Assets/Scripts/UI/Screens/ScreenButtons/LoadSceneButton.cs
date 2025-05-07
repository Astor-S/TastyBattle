using System;
using UnityEngine;
using NaughtyAttributes;
using GameService;
using YG;

namespace UI.Screens.ScreenButtons
{
    public class LoadSceneButton : MonoBehaviour
    {
        [Scene]
        [SerializeField] private string _sceneToLoad;
        [SerializeField] private LevelLoader _levelLoader;

        public event Action GameContinued;

        public void OnButtonClick()
        {
            YG2.InterstitialAdvShow();
            StartCoroutine(_levelLoader.LoadLevelAsync(_sceneToLoad));
            GameContinued?.Invoke();
        }
    }
}