using System.Collections;
using UnityEngine;
using AttackSystem;

namespace FactionalAbilities.Handlers.Debuffs
{
    public class AcidHandler : DebuffHandler
    {
        private const float TickInterval = 1f;

        private DamagableTarget _target;
        private Coroutine _acidCoroutine;
        private ParticleSystem _acidParticleEffect;

        private float _damagePerSecond;
        private float _duration;

        private void OnDestroy()
        {
            if (_acidParticleEffect != null) 
                Destroy(_acidParticleEffect.gameObject);
        }

        public void Initialize(DamagableTarget target, float damagePerSecond, float duration, ParticleSystem acidParticleEffect)
        {
            _target = target;
            _damagePerSecond = damagePerSecond;
            _duration = duration;
            _acidParticleEffect = acidParticleEffect;
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