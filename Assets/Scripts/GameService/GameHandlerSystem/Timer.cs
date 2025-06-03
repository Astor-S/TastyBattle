using System.Collections;
using UnityEngine;
using TMPro;

namespace GameService.GameHandlerSystem
{
    public class Timer : MonoBehaviour
    {
        private const string TwoDigitFormat = "D2";
        private const string Colon = ":";
        private const int SecondsInMinute = 60;

        [SerializeField] private TMP_Text _timerView;

        private float startTime;
        private bool timerRunning = false;

        private void Start()
        {
            if (_timerView == null)
            {
                enabled = false;

                return;
            }

            startTime = Time.time;
            timerRunning = true;
            StartCoroutine(UpdateTimerCoroutine());
        }

        public string GetCurrentTime()
        {
            float timeElapsed = Time.time - startTime;

            string minutes = ((int)timeElapsed / SecondsInMinute).ToString(TwoDigitFormat);
            string seconds = Mathf.FloorToInt(timeElapsed % SecondsInMinute).ToString(TwoDigitFormat);

            return minutes + Colon + seconds;
        }

        private IEnumerator UpdateTimerCoroutine()
        {
            while (timerRunning)
            {
                float timeElapsed = Time.time - startTime;

                string minutes = ((int)timeElapsed / SecondsInMinute).ToString(TwoDigitFormat);
                string seconds = Mathf.FloorToInt(timeElapsed % SecondsInMinute).ToString(TwoDigitFormat);

                _timerView.text = minutes + Colon + seconds;

                yield return null; 
            }
        }
    }
}