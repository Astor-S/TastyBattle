using System.Collections;
using UnityEngine;

namespace GameService.GameHandlerSystem
{
    public class PauseHandler : MonoBehaviour
    {
        private readonly float _pauseDelayForSeconds = 0.1f;
        
        private WaitForSeconds _waitPauseDelayForSeconds;

        private void Awake()
        {
            _waitPauseDelayForSeconds = new WaitForSeconds(_pauseDelayForSeconds);
        }

        public IEnumerator PauseGameDelayed()
        {
            yield return _waitPauseDelayForSeconds;

            PauseGame();
        }

        private void PauseGame() =>
            Time.timeScale = 0f;

        private void ContinueGame() =>
            Time.timeScale = 1f;
    }
}