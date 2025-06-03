using AttackSystem.AttackHandlers;
using FactionalAbilities.Handlers.Debuffs;
using UnityEngine;

namespace FactionalAbilities.Handlers
{
    public class OrangeAbilityHandler : MonoBehaviour
    {
        [SerializeField] private AttackHandler _attackHandler;
        [SerializeField] private OrangeAbility _orangeAbility;
        [SerializeField] private ParticleSystem _acidParticleEffectPrefab;

        private void OnEnable()
        {
            _attackHandler.HitExcecuting += ApplyDebuff;
        }

        private void OnDisable()
        {
            _attackHandler.HitExcecuting -= ApplyDebuff;
        }

        public void ApplyDebuff()
        {
            if (_attackHandler.AttackedTarget == null || _attackHandler.AttackedTarget.gameObject.activeInHierarchy == false)
                return;

            if (_attackHandler.AttackedTarget.TryGetComponent<AcidHandler>(out _) == false)
            {
                ParticleSystem acidParticleEffectInstance = PlayDebuffParticleEffect(_attackHandler.AttackedTarget.transform);

                _attackHandler.AttackedTarget.gameObject.AddComponent<AcidHandler>()
                        .Initialize(
                        _attackHandler.AttackedTarget,
                        _orangeAbility.DamagePerSecond,
                        _orangeAbility.Duration,
                        acidParticleEffectInstance);
            }
        }

        public ParticleSystem PlayDebuffParticleEffect(Transform target)
        {
            float quaternionX = -90f;
            float quaternionY = 0f;
            float quaternionZ = 0f;

            if (_acidParticleEffectPrefab != null)
            {
                ParticleSystem acidParticleEffect =
                    Instantiate(
                        _acidParticleEffectPrefab,
                        target.position,
                        Quaternion.Euler(quaternionX, quaternionY, quaternionZ),
                        target);

                ParticleSystem.MainModule mainModule = acidParticleEffect.main;
                mainModule.stopAction = ParticleSystemStopAction.Destroy;
                acidParticleEffect.Play();

                return acidParticleEffect;
            }

            return null;
        }
    }
}