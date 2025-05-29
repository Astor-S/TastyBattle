using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class SpawnerView : MonoBehaviour
    {
        private const float FullFill = 1f;

        [SerializeField] private Image _timerBar;
        [SerializeField] private float _punchDuration = 1;
        [SerializeField] private int _punchVibrato = 1;
        [SerializeField][Range(0, 1)] private float _punchElasticity = 0;

        private Vector3 _punch = Vector3.one / 2;
        private WaitForFixedUpdate _waitForFixedUpdate;

        private void Awake() =>
            _waitForFixedUpdate = new WaitForFixedUpdate();

        public void StartCountSpawnTime(float spawnTime) =>
            StartCoroutine(CountSpawnTime(spawnTime));

        private IEnumerator CountSpawnTime(float spawnTime)
        {
            _timerBar.fillAmount = default;
            float step = FullFill / spawnTime;

            while (enabled)
            {
                _timerBar.fillAmount = Mathf.MoveTowards(_timerBar.fillAmount, FullFill, step * Time.deltaTime);

                yield return _waitForFixedUpdate;

                if (_timerBar.fillAmount >= FullFill)
                {
                    _timerBar.fillAmount = default;
                    _timerBar.transform.DOPunchScale(_punch, _punchDuration, _punchVibrato, _punchElasticity);
                }
            }
        }
    }
}