using System.Collections;
using UnityEngine;
using AttackSystem;

namespace FactionalAbilities.Handlers.Effects
{
    public class AcidHandler : MonoBehaviour
    {
        private const float TickInterval = 1f;

        private DamagableTarget _target;
        private Coroutine _acidCoroutine;
        private float _damagePerSecond;
        private float _duration;

        public void Initialize(DamagableTarget target, float damagePerSecond, float duration)
        {
            _target = target;
            _damagePerSecond = damagePerSecond;
            _duration = duration;
            _acidCoroutine = StartCoroutine(AcidDamage());
        }

        private IEnumerator AcidDamage()
        {
            float elapsedTime = 0f;

            while (elapsedTime < _duration)
            {
                _target.TakeDamage(_damagePerSecond * TickInterval);
                elapsedTime += TickInterval;
                
                yield return new WaitForSeconds(TickInterval);
            }

            Destroy(this); 
        }
    }
}