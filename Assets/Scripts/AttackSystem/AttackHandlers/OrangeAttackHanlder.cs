using UnityEngine;
using FactionalAbilities.Handlers;
using FactionalAbilities.Handlers.Debuffs;
using AttackSystem.Interfaces;

namespace AttackSystem.AttackHandlers
{
    public class OrangeAttackHanlder : AttackHandler, IOrangeAttacker, IAcidEffector
    {
        [SerializeField] private OrangeAbilityHandler _orangeAbilityHandler;
        [SerializeField] private ParticleSystem _acidParticleEffectPrefab;

        public override void Hit()
        {
            ApplyOrangeAcid();
            base.Hit(); 
        }

        public void ApplyOrangeAcid()
        {
            if (_orangeAbilityHandler != null)
            {
                if (AttackedTarget != null && AttackedTarget.gameObject.activeInHierarchy)
                {
                    AcidHandler acidHandler = AttackedTarget.GetComponent<AcidHandler>();

                    if (acidHandler == null)
                    {
                        ParticleSystem acidParticleEffectInstance = PlayAcidParticleEffect(AttackedTarget.transform);
                        acidHandler = AttackedTarget.gameObject.AddComponent<AcidHandler>();
                        acidHandler.Initialize(AttackedTarget, _orangeAbilityHandler.OrangeAbility.DamagePerSecond, _orangeAbilityHandler.OrangeAbility.Duration, acidParticleEffectInstance);
                    }
                }
            }
        }

        public ParticleSystem PlayAcidParticleEffect(Transform target)
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