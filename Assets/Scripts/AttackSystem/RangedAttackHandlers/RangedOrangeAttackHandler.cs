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
            base.Hit();
            ApplyDebuff();
        }

        public void ApplyDebuff()
        {
            if (_orangeAbilityHandler != null)
            {
                if (AttackedTarget != null && AttackedTarget.gameObject.activeInHierarchy)
                {
                    AcidHandler acidHandler = AttackedTarget.GetComponent<AcidHandler>();

                    if (acidHandler == null)
                    {
                        ParticleSystem acidParticleEffectInstance = PlayDebuffParticleEffect(AttackedTarget.transform);
                        acidHandler = AttackedTarget.gameObject.AddComponent<AcidHandler>();
                        acidHandler.Initialize(AttackedTarget, _orangeAbilityHandler.OrangeAbility.DamagePerSecond, _orangeAbilityHandler.OrangeAbility.Duration, acidParticleEffectInstance);
                    }
                }
            }
        }

        public ParticleSystem PlayDebuffParticleEffect(Transform target)
        {
            if (_acidParticleEffectPrefab != null)
            {
                ParticleSystem acidParticleEffect = Instantiate(_acidParticleEffectPrefab, target.position, Quaternion.Euler(-90f, 0f, 0f), target);
                ParticleSystem.MainModule mainModule = acidParticleEffect.main;
                mainModule.stopAction = ParticleSystemStopAction.Destroy;
                acidParticleEffect.Play();

                return acidParticleEffect;
            }

            return null;
        }
    }
}