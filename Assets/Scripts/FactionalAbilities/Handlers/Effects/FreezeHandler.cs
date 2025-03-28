using System.Collections;
using UnityEngine;
using Units;

namespace FactionalAbilities.Handlers.Effects
{
    public class FreezeHandler : MonoBehaviour
    {
        private const float DamageMultiplierBase = 1f;

        private Unit _unit;

        private float _totalSlowPercentage;
        private float _maxSlowPercentage;
        private float _slowDuration;
        private float _defaultMovementSpeed;
        private float _defaultAttackSpeed;

        private bool _isFreezing = false;

        public void Initialize(Unit unit, float slowPercentage, float slowDuration, float maxSlowPercentage)
        {
            _unit = unit;
            _defaultMovementSpeed = unit.Stats.MovementSpeed;
            _defaultAttackSpeed = unit.Stats.AttackSpeed;
            _slowDuration = slowDuration;
            _maxSlowPercentage = maxSlowPercentage;
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
            //_unit.Stats.MovementSpeed = _defaultMovementSpeed * (DamageMultiplierBase - _totalSlowPercentage);
            //_unit.Stats.AttackSpeed = _defaultAttackSpeed * (DamageMultiplierBase - _totalSlowPercentage);
        }

        private IEnumerator SlowDurationCoroutine()
        {
            _isFreezing = true;
            yield return new WaitForSeconds(_slowDuration);
            ResetSlow();
        }

        private void ResetSlow()
        {
            _isFreezing = false;
            _totalSlowPercentage = 0;
            //_unit.Stats.MovementSpeed = _defaultMovementSpeed;
            //_unit.Stats.AttackSpeed = _defaultAttackSpeed;
            Destroy(this);
        }
    }
}