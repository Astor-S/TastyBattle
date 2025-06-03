using UnityEngine;
using AttackSystem.Interfaces;
using FactionalAbilities.Handlers;
using FactionalAbilities.Handlers.Debuffs;

namespace AttackSystem.RangedAttackHandlers
{
    public class RangedOrangeAttackHandler : RangedAttackHandler, IDebuffAttacker, IDebuffEffector
    {
        [SerializeField] private OrangeAbilityHandler _orangeAbilityHandler;
        [SerializeField] private ParticleSystem _acidParticleEffectPrefab;

        public override void Hit()
        {
            ApplyDebuff();
            base.Hit();
        }

        public void ApplyDebuff()
        {
            if (_orangeAbilityHandler == null)
                return;

            if (AttackedTarget == null || AttackedTarget.gameObject.activeInHierarchy == false)
                return;

            if (AttackedTarget.TryGetComponent<AcidHandler>(out _) == false)
            {
                ParticleSystem acidParticleEffectInstance = PlayDebuffParticleEffect(AttackedTarget.transform);

                AttackedTarget.gameObject.AddComponent<AcidHandler>()
                        .Initialize(
                        AttackedTarget,
                        _orangeAbilityHandler.OrangeAbility.DamagePerSecond,
                        _orangeAbilityHandler.OrangeAbility.Duration,
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