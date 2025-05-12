using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace GameService.GameHandlerSystem.Handlers
{
    public class PauseHandler : MonoBehaviour
    {
        private readonly float _pauseDelayForSeconds = 0.1f;

        [SerializeField] private Button _homeButtonInPausePanel;
        [SerializeField] private Button _restartButtonInPausePanel;

        private WaitForSeconds _waitPauseDelayForSeconds;

        private void Awake()
        {
            _waitPauseDelayForSeconds = new WaitForSeconds(_pauseDelayForSeconds);
        }

        private void OnEnable()
        {
            if(_homeButtonInPausePanel != null)
               _homeButtonInPausePanel.onClick.AddListener(ContinueGame);

            if (_restartButtonInPausePanel != null)
                _restartButtonInPausePanel.onClick.AddListener(ContinueGame);
        }

        private void OnDisable()
        {
            if (_homeButtonInPausePanel != null)
                _homeButtonInPausePanel.onClick.RemoveListener(ContinueGame);

            if (_restartButtonInPausePanel != null)
                _restartButtonInPausePanel.onClick.RemoveListener(ContinueGame);
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