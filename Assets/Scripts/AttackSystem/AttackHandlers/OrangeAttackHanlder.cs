using UnityEngine;
using FactionalAbilities.Handlers;
using FactionalAbilities.Handlers.Effects;
using AttackSystem.Interfaces;

namespace AttackSystem.AttackHandlers
{
    public class OrangeAttackHanlder : AttackHandler, IOrangeAttacker, IAcidEffector
    {
        [SerializeField] private OrangeAbilityHandler _orangAbilityHandler;
        [SerializeField] private ParticleSystem _acidParticleEffectPrefab;

        public override void Hit()
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
                ParticleSystem acidParticleEffect = Instantiate(_acidParticleEffectPrefab, target.position, Quaternion.Euler(-90f,0f,0f), target);
                ParticleSystem.MainModule mainModule = acidParticleEffect.main;
                mainModule.stopAction = ParticleSystemStopAction.Destroy;
                acidParticleEffect.Play();
            }
        }
    }
}