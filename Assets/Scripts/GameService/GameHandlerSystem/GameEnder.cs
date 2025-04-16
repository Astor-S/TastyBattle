using UnityEngine;
using UI.Screens;

namespace GameService.GameHandlerSystem
{
    public class GameEnder : MonoBehaviour
    {
        [SerializeField] private FailScreen _failScreen;
        [SerializeField] private PauseHandler _pauseHandler;

        public void HandleGameOver()
        {
            _failScreen.Open();
            StartCoroutine(_pauseHandler.PauseGameDelayed());
        }
    }
}