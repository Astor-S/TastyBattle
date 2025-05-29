using System.Collections;
using UnityEngine;
using Units;

namespace FactionalAbilities.Handlers.Debuffs
{
    public class FreezeHandler : DebuffHandler
    {
        private const float DamageMultiplierBase = 1f;

        private UnitPresenter _unitPresenter;
        private ParticleSystem _freezeParticleEffect;

        private float _totalSlowPercentage;
        private float _maxSlowPercentage;
        private float _defaultMovementSpeed;
        private float _slowDecreaseRate;

        private bool _isFreezing = false;

        private void OnDestroy()
        {
            if (_freezeParticleEffect != null)
                Destroy(_freezeParticleEffect.gameObject);
        }

        public void Initialize(UnitPresenter unitPresenter, float slowPercentage, float maxSlowPercentage, float slowDecreaseRate, ParticleSystem freezeParticleEffect)
        {
            _unitPresenter = unitPresenter;
            _defaultMovementSpeed = unitPresenter.Model.Stats.MovementSpeed;
            _maxSlowPercentage = maxSlowPercentage;
            _slowDecreaseRate = slowDecreaseRate;
            _freezeParticleEffect = freezeParticleEffect;
            ApplySlow(slowPercentage);
        }

        public void ApplySlow(float slowPercentage)
        {
            _totalSlowPercentage += slowPercentage;
            _totalSlowPercentage = Mathf.Clamp(_totalSlowPercentage, 0, _maxSlowPercentage);
            UpdateSlow();
 
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
            float newAttackSpeedMultiplier = DamageMultiplierBase - _totalSlowPercentage;
            _unitPresenter.SetAgentSpeed(newMovementSpeed);
            _unitPresenter.SetAttackSpeedMultiplier(newAttackSpeedMultiplier);
        }

        private IEnumerator SlowDurationCoroutine()
        {
            _isFreezing = true;       

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
            _unitPresenter.ResetAttackSpeedMultiplier();
            Destroy(this);
        }
    }
}