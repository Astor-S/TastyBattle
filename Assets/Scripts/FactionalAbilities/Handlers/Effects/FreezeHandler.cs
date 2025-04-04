using System.Collections;
using UnityEngine;
using Units;

namespace FactionalAbilities.Handlers.Effects
{
    public class FreezeHandler : MonoBehaviour
    {
        private const float DamageMultiplierBase = 1f;

        private UnitPresenter _unitPresenter;

        private float _totalSlowPercentage;
        private float _maxSlowPercentage;
        private float _slowDuration;
        private float _defaultMovementSpeed;
        private float _defaultAttackSpeed;
        private float _slowDecreaseRate;

        private bool _isFreezing = false;

        public void Initialize(UnitPresenter unitPresenter, float slowPercentage, float slowDuration, float maxSlowPercentage, float slowDecreaseRate)
        {
            _unitPresenter = unitPresenter;
            _defaultMovementSpeed = unitPresenter.Model.Stats.MovementSpeed;
            _defaultAttackSpeed = unitPresenter.Model.Stats.AttackSpeed;
            _slowDuration = slowDuration;
            _maxSlowPercentage = maxSlowPercentage;
            _slowDecreaseRate = slowDecreaseRate;
            ApplySlow(slowPercentage);
        }

        public void ApplySlow(float slowPercentage)
        {
            _totalSlowPercentage += slowPercentage;
            _totalSlowPercentage = Mathf.Clamp(_totalSlowPercentage, 0, _maxSlowPercentage);
            UpdateSlow();

            Debug.Log($"[FreezeHandler] Применение замедления к {gameObject.name}. Общий процент замедления: {_totalSlowPercentage}");

            if (_isFreezing == false)
                StartCoroutine(SlowDurationCoroutine());
        }
        private void RemoveSlow(float slowPercentage)
        {
            _totalSlowPercentage -= slowPercentage;
            _totalSlowPercentage = Mathf.Clamp(_totalSlowPercentage, 0, _maxSlowPercentage);
            UpdateSlow();
        }

        private void UpdateSlow()
        {
            float newMovementSpeed = _defaultMovementSpeed * (DamageMultiplierBase - _totalSlowPercentage);
            float newAttackSpeed = _defaultAttackSpeed * (DamageMultiplierBase - _totalSlowPercentage);
            _unitPresenter.SetAgentSpeed(newMovementSpeed);
            _unitPresenter.SetAttackSpeed(newAttackSpeed);
        }

        private IEnumerator SlowDurationCoroutine()
        {
            _isFreezing = true;
            Debug.Log($"[FreezeHandler] Запуск корутины длительности замедления на {gameObject.name}. Длительность: {_slowDuration}");

            while (_totalSlowPercentage > 0)
            {
                float decreaseAmount = _slowDecreaseRate * Time.deltaTime;
                RemoveSlow(decreaseAmount); 

                yield return null;
            }

            ResetSlow();
        }

        private void ResetSlow()
        {
            _isFreezing = false;
            _totalSlowPercentage = 0;
            _unitPresenter.ResetAgentSpeed();
            _unitPresenter.ResetAttackSpeed();
            Destroy(this);
        }
    }
}