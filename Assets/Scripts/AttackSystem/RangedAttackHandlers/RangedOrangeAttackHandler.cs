using UnityEngine;
using AttackSystem.Interfaces;
using FactionalAbilities.Handlers.Effects;
using FactionalAbilities.Handlers;

namespace AttackSystem.RangedAttackHandlers
{
    public class RangedOrangeAttackHandler : RangedAttackHandler, IOrangeAttacker, IPlayerAcidEffect
    {
        [SerializeField] private OrangeAbilityHandler _orangAbilityHandler;
        [SerializeField] private ParticleSystem _acidParticleEffectPrefab;

        protected override void Hit()
        {
            base.Hit();
            ApplyOrangeAcid();
        }

        public void ApplyOrangeAcid()
        {
            if (_orangAbilityHandler != null)
            {
                if (AttackedTarget != null)
                {
                    AcidHandler acidHandler = AttackedTarget.GetComponent<AcidHandler>();

                    if (acidHandler == null)
                    {
                        acidHandler = AttackedTarget.gameObject.AddComponent<AcidHandler>();
                        acidHandler.Initialize(AttackedTarget, _orangAbilityHandler.OrangeAbility.DamagePerSecond, _orangAbilityHandler.OrangeAbility.Duration);
                        PlayAcidParticleEffect(AttackedTarget.transform);
                    }
                }
            }
        }

        public void PlayAcidParticleEffect(Transform target)
        {
            if (_acidParticleEffectPrefab != null)
            {
                ParticleSystem acidParticleEffect = Instantiate(_acidParticleEffectPrefab, target.position, Quaternion.Euler(-90f, 0f, 0f), target);
                ParticleSystem.MainModule mainModule = acidParticleEffect.main;
                mainModule.stopAction = ParticleSystemStopAction.Destroy;
                acidParticleEffect.Play();
            }
        }
    }
}