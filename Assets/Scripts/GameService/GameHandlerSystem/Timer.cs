using System.Collections;
using UnityEngine;
using TMPro;

namespace GameService.GameHandlerSystem
{
    public class Timer : MonoBehaviour
    {
        private const string TwoDigitFormat = "D2";
        private const string Colon = ":";

        [SerializeField] private TMP_Text timerText;

        private float startTime;
        private bool timerRunning = false;

        private void Start()
        {
            if (timerText == null)
            {
                enabled = false;

                return;
            }

            startTime = Time.time;
            timerRunning = true;
            StartCoroutine(UpdateTimerCoroutine());
        }

        private IEnumerator UpdateTimerCoroutine()
        {
            int secondsInMinute = 60;

            while (timerRunning)
            {
                float timeElapsed = Time.time - startTime;

                string minutes = ((int)timeElapsed / secondsInMinute).ToString(TwoDigitFormat);
                string seconds = Mathf.FloorToInt(timeElapsed % secondsInMinute).ToString(TwoDigitFormat);

                timerText.text = minutes + Colon + seconds;

                yield return null; 
            }
        }
    }
}